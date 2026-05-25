using DormitoryObjects;
using DormitoryObjects.Databases;
using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using DormitoryObjects.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DormitoryTest
{
    public class RoomServiceTest
    {
        private readonly Mock<IDbFactory> _dbFactoryMock;
        private readonly Mock<IRepositoryFactory> _repoFactoryMock;
        private readonly Mock<IDormitoryDatabase> _dbMock;
        private readonly Mock<IRoomAdvancedRepository> _roomRepoMock;
        private readonly RoomService _service;

        public RoomServiceTest()
        {
            _dbFactoryMock = new Mock<IDbFactory>();
            _repoFactoryMock = new Mock<IRepositoryFactory>();
            _dbMock = new Mock<IDormitoryDatabase>();
            _roomRepoMock = new Mock<IRoomAdvancedRepository>();

            _dbFactoryMock.Setup(f => f.Create()).Returns(_dbMock.Object);
            _repoFactoryMock.Setup(f => f.CreateRoomRepository(It.IsAny<IDormitoryDatabase>()))
                            .Returns(_roomRepoMock.Object);

            _service = new RoomService(_dbFactoryMock.Object, _repoFactoryMock.Object);
        }

        [Fact]
        public async Task GetRooms_ReturnsAllRooms()
        {
            // Arrange
            var rooms = new List<Room> { new Room { RoomID = 1 }, new Room { RoomID = 2 } };
            _roomRepoMock.Setup(r => r.GetAll()).ReturnsAsync(rooms);

            // Act
            var result = await _service.GetRooms();

            // Assert
            Assert.Equal(2, result.Count());
            _roomRepoMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public async Task GetFilteredRooms_CallsFilterWithCorrectValue()
        {
            // Arrange
            int freePlaces = 2;
            _roomRepoMock.Setup(r => r.FilterRoomByOccupancy(freePlaces))
                         .ReturnsAsync(new List<Room> { new Room() });

            // Act
            var result = await _service.GetFilteredRooms(freePlaces);

            // Assert
            Assert.Single(result);
            _roomRepoMock.Verify(r => r.FilterRoomByOccupancy(freePlaces), Times.Once);
        }

        [Fact]
        public async Task GetFloors_ReturnsListOfFloors()
        {
            // Arrange
            var floors = new List<int> { 1, 2, 3 };
            _roomRepoMock.Setup(r => r.GetFloors()).ReturnsAsync(floors);

            // Act
            var result = await _service.GetFloors();

            // Assert
            Assert.Equal(3, result.Count());
            Assert.Contains(2, result);
        }

        [Fact]
        public async Task GetNumbersFromFloor_ReturnsCorrectNumbers()
        {
            // Arrange
            int floor = 5;
            var numbers = new List<int> { 501, 502 };
            _roomRepoMock.Setup(r => r.GetNumbersFromFloor(floor)).ReturnsAsync(numbers);

            // Act
            var result = await _service.GetNumbersFromFloor(floor);

            // Assert
            Assert.Equal(2, result.Count());
            _roomRepoMock.Verify(r => r.GetNumbersFromFloor(floor), Times.Once);
        }

        [Fact]
        public async Task GetRoomsFromFloor_ReturnsCorrectRooms()
        {
            // Arrange
            int floor = 2;
            var rooms = new List<Room> { new Room { RoomID = 10, Floor = 2 } };
            _roomRepoMock.Setup(r => r.GetRoomsFromFloor(floor)).ReturnsAsync(rooms);

            // Act
            var result = await _service.GetRoomsFromFloor(floor);

            // Assert
            Assert.Single(result);
            Assert.Equal(10, result.First().RoomID);
        }

        [Fact]
        public async Task GetRoomByFloorAndNumber_ReturnsCorrectRoom()
        {
            // Arrange
            int floor = 3;
            int number = 305;
            var room = new Room { RoomID = 55, Floor = floor, Number = number };
            _roomRepoMock.Setup(r => r.GetRoomByFloorAndNumber(floor, number)).ReturnsAsync(room);

            // Act
            var result = await _service.GetRoomByFloorAndNumber(floor, number);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(55, result.RoomID);
        }

        [Fact]
        public async Task GetRoomById_ReturnsCorrectRoom()
        {
            // Arrange
            int id = 100;
            _roomRepoMock.Setup(r => r.GetById(id)).ReturnsAsync(new Room { RoomID = id });

            // Act
            var result = await _service.GetRoomById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(id, result.RoomID);
        }
    }
}