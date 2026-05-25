using DormitoryObjects;
using DormitoryObjects.Databases;
using DormitoryObjects.DTO;
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
    public class InventoryServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;

        private readonly Mock<IInventoryRepository> _inventoryRepoMock;
        private readonly Mock<IInventoryTypeRepository> _typeRepoMock;
        private readonly Mock<IInventoryStateRepository> _stateRepoMock;
        private readonly Mock<IRoomAdvancedRepository> _roomRepoMock;

        private readonly InventoryService _service;

        public InventoryServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();

            _inventoryRepoMock = new Mock<IInventoryRepository>();
            _typeRepoMock = new Mock<IInventoryTypeRepository>();
            _stateRepoMock = new Mock<IInventoryStateRepository>();
            _roomRepoMock = new Mock<IRoomAdvancedRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);

            _repoFactoryMock.Setup(f => f.CreateInventoryRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_inventoryRepoMock.Object);
            _repoFactoryMock.Setup(f => f.CreateInventoryTypeRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_typeRepoMock.Object);
            _repoFactoryMock.Setup(f => f.CreateInventoryStateRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_stateRepoMock.Object);
            _repoFactoryMock.Setup(f => f.CreateRoomRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_roomRepoMock.Object);

            _service = new InventoryService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetInventory_ReturnsCorrectList()
        {
            // Arrange
            var list = new List<Inventory>
            {
                new Inventory { ItemID = 1, PurchaseDate = DateTime.Now },
                new Inventory { ItemID = 2, PurchaseDate = DateTime.Now }
            };
            _inventoryRepoMock.Setup(r => r.GetAll()).ReturnsAsync(list);

            // Act
            var result = await _service.GetInventory();

            // Assert
            Assert.Equal(2, result.Count());
            _inventoryRepoMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetInventoryById_ReturnsCorrectItem()
        {
            // Arrange
            var item = new Inventory { ItemID = 10 };
            _inventoryRepoMock.Setup(r => r.GetById(10)).ReturnsAsync(item);

            // Act
            var result = await _service.GetInventoryById(10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.ItemID);
        }


        [Fact]
        public async Task AddInventory_ValidData_CallsCreate()
        {
            // Arrange
            var date = DateTime.Now;
            _typeRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(new InventoryType());
            _stateRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(new InventoryState());

            // Act
            await _service.AddInventory(1, 1, date);

            // Assert
            _inventoryRepoMock.Verify(r => r.Create(It.Is<Inventory>(i =>
                i.TypeID == 1 &&
                i.StateID == 1 &&
                i.PurchaseDate == date)), Times.Once);
        }

        [Fact]
        public async Task RemoveInventory_ItemExists_CallsDelete()
        {
            // Arrange
            _inventoryRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(new Inventory());

            // Act
            await _service.RemoveInventory(1);

            // Assert
            _inventoryRepoMock.Verify(r => r.Delete(1), Times.Once);
        }


        [Fact]
        public async Task UpdateInventoryCondition_SetToRepair_ClearsRoomId()
        {
            // Arrange
            var item = new Inventory { ItemID = 1, RoomID = 5, StateID = 1 };
            _inventoryRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(item);

            // Act: 3 - Ремонт
            await _service.UpdateInventoryCondition(1, 3);

            // Assert
            Assert.Null(item.RoomID);
            Assert.Equal(3, item.StateID);
        }

        [Fact]
        public async Task SetInventoryForRoom_ValidItem_UpdatesSuccessfully()
        {
            // Arrange
            var item = new Inventory { ItemID = 1, StateID = 1 }; 
            _inventoryRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(item);
            _roomRepoMock.Setup(r => r.GetById(101)).ReturnsAsync(new Room());

            // Act
            await _service.SetInventoryForRoom(1, 101);

            // Assert
            Assert.Equal(101, item.RoomID);
        }

        [Theory]
        [InlineData(3, "Нельзя назначить предмет, который в ремонте")]
        [InlineData(4, "Нельзя назначить предмет, который списан")]
        public async Task SetInventoryForRoom_InvalidState_ThrowsException(int badState, string expectedMsg)
        {
            // Arrange
            var item = new Inventory { ItemID = 1, StateID = badState };
            _inventoryRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(item);
            _roomRepoMock.Setup(r => r.GetById(101)).ReturnsAsync(new Room());

            // Act
            var ex = await Assert.ThrowsAsync<Exception>(() => _service.SetInventoryForRoom(1, 101));
            // Assert
            Assert.Equal(expectedMsg, ex.Message);
            _inventoryRepoMock.Verify(r => r.Update(It.IsAny<Inventory>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task RemoveInventoryFromRoom_ClearsRoomId()
        {
            // Arrange
            var item = new Inventory { ItemID = 1, RoomID = 101 };
            _inventoryRepoMock.Setup(r => r.GetById(1)).ReturnsAsync(item);

            // Act
            await _service.RemoveInventoryFromRoom(1);

            // Assert
            Assert.Null(item.RoomID);
        }

    }
}