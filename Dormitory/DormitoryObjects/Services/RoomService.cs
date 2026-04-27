using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class RoomService
    {
        private readonly IDbFactory _factory;
        public RoomService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<Room>> GetRooms()
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task<IEnumerable<Room>> GetFilteredRooms(int roomsCount)
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.FilterRoomByOccupancy(roomsCount);
            }
        }
        public async Task<IEnumerable<int>> GetFloors()
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetFloors();
            }
        }
        public async Task<IEnumerable<int>> GetNumbersFromFloor(int floor)
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetNumbersFromFloor(floor);
            }
        }
        public async Task<IEnumerable<Room>> GetRoomsFromFloor(int floor)
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetRoomsFromFloor(floor);
            }
        }
        public async Task<Room> GetRoomByFloorAndNumber(int floor, int number)
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetRoomByFloorAndNumber(floor, number);
            }
        }
    }
}
