using DormitoryObjects;
using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.RepositoriesInterfaces;
using DormitoryObjects.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class BenefitTypeServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IBenefitTypeRepository> _benefitRepoMock;
        private readonly BenefitTypeService _service;

        public BenefitTypeServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _benefitRepoMock = new Mock<IBenefitTypeRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreateBenefitTypeRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_benefitRepoMock.Object);

            _service = new BenefitTypeService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetBenefitTypes_ReturnsAllTypes()
        {
            // Arrange
            var benefits = new List<BenefitType>
            {
                new BenefitType { BenefitID = 1, Name = "Сирота" },
                new BenefitType { BenefitID = 2, Name = "Инвалид" }
            };
            _benefitRepoMock.Setup(r => r.GetAll()).ReturnsAsync(benefits);

            // Act
            var result = await _service.GetBenefitTypes();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Сирота", result.First().Name);
        }

        [Fact]
        public async Task GetBenefitsID_ReturnsOnlyIdentifiers()
        {
            // Arrange
            var benefits = new List<BenefitType>
            {
                new BenefitType { BenefitID = 101 },
                new BenefitType { BenefitID = 102 }
            };
            _benefitRepoMock.Setup(r => r.GetAll()).ReturnsAsync(benefits);

            // Act
            var result = await _service.GetBenefitsID();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(101, result);
            Assert.Contains(102, result);
        }

        [Fact]
        public async Task GetBenefitTypeById_ReturnsCorrectBenefit()
        {
            // Arrange
            int id = 1;
            var benefit = new BenefitType { BenefitID = id, Name = "Ветеран" };
            _benefitRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(benefit);

            // Act
            var result = await _service.GetBenefitTypeById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.BenefitID);
            Assert.Equal("Ветеран", result.Name);
        }
    }
}