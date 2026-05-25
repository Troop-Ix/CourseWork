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
    public class StudentServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IStudentAdvancedRepository> _studentRepoMock;
        private readonly Mock<IRoomAdvancedRepository> _roomRepoMock;
        private readonly StudentsService _service;

        public StudentServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _studentRepoMock = new Mock<IStudentAdvancedRepository>();
            _roomRepoMock = new Mock<IRoomAdvancedRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreateStudentAdvancedRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_studentRepoMock.Object);
            _repoFactoryMock.Setup(f => f.CreateRoomRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_roomRepoMock.Object);

            _service = new StudentsService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetStudentsBySurname_EmptySurname_CallsGetAll()
        {
            // Act
            await _service.GetStudentsBySurname("");

            // Assert
            _studentRepoMock.Verify(r => r.GetAll(), Times.Once);
            _studentRepoMock.Verify(r => r.GetStudentsBySurname(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetStudentsBySurname_WithName_CallsSpecificMethod()
        {
            // Arrange
            string surname = "Korobov";
            _studentRepoMock.Setup(r => r.GetStudentsBySurname(surname)).ReturnsAsync(new List<Student>());

            // Act
            await _service.GetStudentsBySurname(surname);

            // Assert
            _studentRepoMock.Verify(r => r.GetStudentsBySurname(surname), Times.Once);
        }

        [Fact]
        public async Task EvictStudent_StudentExists_SetsRoomToNull()
        {
            // Arrange
            int id = 1;
            var student = new Student { StudentID = id, RoomID = 101 };
            _studentRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(student);

            // Act
            await _service.EvictStudent(id);

            // Assert
            Assert.Null(student.RoomID);
            _studentRepoMock.Verify(r => r.Update(student, id), Times.Once);
        }

        [Theory]
        [InlineData(2, 2)] 
        [InlineData(3, 2)] 
        public async Task SetRoomForStudent_NoSpace_ThrowsException(int currentStudents, int capacity)
        {
            // Arrange
            int roomId = 5;
            var room = new Room
            {
                RoomID = roomId,
                Capacity = capacity,
                Students = Enumerable.Repeat(new Student(), currentStudents).ToList()
            };
            _roomRepoMock.Setup(r => r.GetById(roomId)).ReturnsAsync(room);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => _service.SetRoomForStudent(1, roomId));
            Assert.Equal("Не хватает мест в заданной комнате", ex.Message);
            _studentRepoMock.Verify(r => r.Update(It.IsAny<Student>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task SetRoomForStudent_HasSpace_UpdatesStudent()
        {
            // Arrange
            int studentId = 1;
            int roomId = 5;
            var room = new Room { RoomID = roomId, Capacity = 4, Students = new List<Student>() };
            var student = new Student { StudentID = studentId, RoomID = null };

            _roomRepoMock.Setup(r => r.GetById(roomId)).ReturnsAsync(room);
            _studentRepoMock.Setup(r => r.GetById(studentId)).ReturnsAsync(student);

            // Act
            await _service.SetRoomForStudent(studentId, roomId);

            // Assert
            Assert.Equal(roomId, student.RoomID);
            _studentRepoMock.Verify(r => r.Update(student, studentId), Times.Once);
        }

        [Fact]
        public async Task GetDebtors_CallsRepositoryMethod()
        {
            // Arrange
            _studentRepoMock.Setup(r => r.GetDebtors()).ReturnsAsync(new List<Student>());

            // Act
            await _service.GetDebtors();

            // Assert
            _studentRepoMock.Verify(r => r.GetDebtors(), Times.Once);
        }
    }
}