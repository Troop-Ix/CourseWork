using DormitoryObjects;
using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using DormitoryObjects.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class StudentBenefitServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IStudentBenefitRepository> _benefitRepoMock;
        private readonly Mock<IStudentAdvancedRepository> _studentRepoMock;
        private readonly Mock<IBenefitTypeRepository> _typeRepoMock;
        private readonly StudentBenefitService _service;

        public StudentBenefitServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();

            _benefitRepoMock = new Mock<IStudentBenefitRepository>();
            _studentRepoMock = new Mock<IStudentAdvancedRepository>();
            _typeRepoMock = new Mock<IBenefitTypeRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);

            _repoFactoryMock.Setup(f => f.CreateStudentBenefitRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_benefitRepoMock.Object);
            _repoFactoryMock.Setup(f => f.CreateStudentAdvancedRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_studentRepoMock.Object);
            _repoFactoryMock.Setup(f => f.CreateBenefitTypeRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_typeRepoMock.Object);

            _service = new StudentBenefitService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task SetBenefitForStudent_ValidData_CallsCreate()
        {
            // Arrange
            int studentId = 1;
            int benefitId = 10;
            var date = DateTime.Now;

            _studentRepoMock.Setup(r => r.GetById(studentId)).ReturnsAsync(new Student());
            _typeRepoMock.Setup(r => r.GetById(benefitId)).ReturnsAsync(new BenefitType());
            _benefitRepoMock.Setup(r => r.GetAll()).ReturnsAsync(new List<StudentBenefit>()); 

            // Act
            await _service.SetBenefitForStudent(studentId, benefitId, date);

            // Assert
            _benefitRepoMock.Verify(r => r.Create(It.Is<StudentBenefit>(b =>
                b.StudentID == studentId &&
                b.BenefitID == benefitId &&
                b.IssueDate == date)), Times.Once);
        }

        [Fact]
        public async Task SetBenefitForStudent_AlreadyHasBenefit_ThrowsException()
        {
            // Arrange
            int studentId = 1;
            int benefitId = 10;
            _studentRepoMock.Setup(r => r.GetById(studentId)).ReturnsAsync(new Student());
            _typeRepoMock.Setup(r => r.GetById(benefitId)).ReturnsAsync(new BenefitType());
            _benefitRepoMock.Setup(r => r.GetAll()).ReturnsAsync(new List<StudentBenefit>
            {
                new StudentBenefit { StudentID = studentId, BenefitID = benefitId }
            });

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _service.SetBenefitForStudent(studentId, benefitId, DateTime.Now));
            Assert.Equal("У этого студента уже есть данная льгота.", ex.Message);
        }

        [Theory]
        [InlineData(true, false, "Студент не найден в базе данных")]
        [InlineData(false, true, "Льгота не найдена в базе данных")]
        public async Task SetBenefitForStudent_EntityNotFound_ThrowsException(bool studentIsNull, bool benefitIsNull, string expectedMsg)
        {
            // Arrange
            int studentId = 1;
            int benefitId = 10;

            _studentRepoMock.Setup(r => r.GetById(studentId))
                            .ReturnsAsync(studentIsNull ? (Student)null : new Student());

            _typeRepoMock.Setup(r => r.GetById(benefitId))
                         .ReturnsAsync(benefitIsNull ? (BenefitType)null : new BenefitType());

            // Act
            var ex = await Assert.ThrowsAsync<Exception>(() =>
                _service.SetBenefitForStudent(studentId, benefitId, DateTime.Now));

            // Assert
            Assert.Equal(expectedMsg, ex.Message);
            _benefitRepoMock.Verify(r => r.Create(It.IsAny<StudentBenefit>()), Times.Never);
        }

        [Fact]
        public async Task RemoveAllBenefitsFromStudent_DeletesMultipleBenefits()
        {
            // Arrange
            int studentId = 1;
            var benefits = new List<StudentBenefit>
            {
                new StudentBenefit { StudentBenefitID = 100 },
                new StudentBenefit { StudentBenefitID = 101 }
            };
            var student = new Student { StudentID = studentId, StudentBenefits = benefits };

            _studentRepoMock.Setup(r => r.GetById(studentId)).ReturnsAsync(student);

            // Act
            await _service.RemoveAllBenefitsFromStudent(studentId);

            // Assert
            _benefitRepoMock.Verify(r => r.Delete(100), Times.Once);
            _benefitRepoMock.Verify(r => r.Delete(101), Times.Once);
        }

        [Fact]
        public async Task GetStudentBenefits_ReturnsAll()
        {
            // Arrange
            _benefitRepoMock.Setup(r => r.GetAll()).ReturnsAsync(new List<StudentBenefit> { new StudentBenefit() });

            // Act
            var result = await _service.GetStudentBenefits();

            // Assert
            Assert.Single(result);
        }

        [Fact]
        public async Task GetstudentBenefitById_ReturnsCorrectBenefit()
        {
            // Arrange
            int id = 50;
            _benefitRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(new StudentBenefit { StudentBenefitID = id });

            // Act
            var result = await _service.GetstudentBenefitById(id);

            // Assert
            Assert.Equal(id, result.StudentBenefitID);
        }
    }
}