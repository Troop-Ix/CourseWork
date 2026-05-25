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
    public class InventoryTypeServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IInventoryTypeRepository> _typeRepoMock;
        private readonly InventoryTypeService _service;

        public InventoryTypeServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _typeRepoMock = new Mock<IInventoryTypeRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreateInventoryTypeRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_typeRepoMock.Object);

            _service = new InventoryTypeService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetInventoryTypes_ReturnsAllTypes()
        {
            // Arrange
            var types = new List<InventoryType>
            {
                new InventoryType { TypeID = 1, Name = "Стол" },
                new InventoryType { TypeID = 2, Name = "Стул" }
            };
            _typeRepoMock.Setup(r => r.GetAll()).ReturnsAsync(types);

            // Act
            var result = await _service.GetInventoryTypes();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Стол", result.First().Name);
        }

        [Fact]
        public async Task GetInventoryTypesID_ReturnsOnlyIdentifiers()
        {
            // Arrange
            var types = new List<InventoryType>
            {
                new InventoryType { TypeID = 50 },
                new InventoryType { TypeID = 60 }
            };
            _typeRepoMock.Setup(r => r.GetAll()).ReturnsAsync(types);

            // Act
            var result = await _service.GetInventoryTypesID();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(50, result);
            Assert.Contains(60, result);
        }

        [Fact]
        public async Task GetInventoryTypeById_ReturnsCorrectType()
        {
            // Arrange
            int id = 5;
            var type = new InventoryType { TypeID = id, Name = "Зеркало" };
            _typeRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(type);

            // Act
            var result = await _service.GetInventoryTypeById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.TypeID);
            Assert.Equal("Зеркало", result.Name);
        }
    }
}