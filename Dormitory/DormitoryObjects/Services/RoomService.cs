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
        public async Task<IEnumerable<Room>> GetEmptyRooms()
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetEmptyRooms();
            }
        }
        public async Task<IEnumerable<Room>> GetFullRooms()
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetFullRooms();
            }
        }
        public async Task<IEnumerable<Room>> GetPartlyOccupiedRooms()
        {
            using (var db = _factory.Create())
            {
                var repo = new RoomAdvancedRepository(db);
                return await repo.GetPartlyOccupiedRooms();
            }
        }
    }
}
