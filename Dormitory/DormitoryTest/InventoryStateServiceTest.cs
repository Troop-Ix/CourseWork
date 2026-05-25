using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class InventoryStateServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IInventoryStateRepository> _stateRepoMock;
        private readonly InventoryStateService _service;

        public InventoryStateServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _stateRepoMock = new Mock<IInventoryStateRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreateInventoryStateRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_stateRepoMock.Object);

            _service = new InventoryStateService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetInventoryStates_ReturnsAllStates()
        {
            // Arrange
            var states = new List<InventoryState>
            {
                new InventoryState { StateID = 1, Name = "исправен" },
                new InventoryState { StateID = 2, Name = "сломан" }
            };
            _stateRepoMock.Setup(r => r.GetAll()).ReturnsAsync(states);

            // Act
            var result = await _service.GetInventoryStates();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("исправен", result.First().Name);
        }

        [Fact]
        public async Task GetInventoryStatesID_ReturnsOnlyIdentifiers()
        {
            // Arrange
            var states = new List<InventoryState>
            {
                new InventoryState { StateID = 10 },
                new InventoryState { StateID = 20 }
            };
            _stateRepoMock.Setup(r => r.GetAll()).ReturnsAsync(states);

            // Act
            var result = await _service.GetInventoryStatesID();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(10, result);
            Assert.Contains(20, result);
        }

        [Fact]
        public async Task GetInventoryStateById_ReturnsCorrectState()
        {
            // Arrange
            int id = 1;
            var state = new InventoryState { StateID = id, Name = "В ремонте" };
            _stateRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(state);

            // Act
            var result = await _service.GetInventoryStateById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.StateID);
            Assert.Equal("В ремонте", result.Name);
        }
    }
}