using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.Async;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSRoomAdvancedRepository : MSRoomRepository, IRoomAdvancedRepository
    {
        public MSRoomAdvancedRepository(MSDormitoryDatabase db) : base(db) { }

        public async Task<IEnumerable<Room>> FilterRoomByOccupancy(int roomsCount)
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).Where(r => r.Students.Count == roomsCount).ToListAsync();
            return rooms;
        }

        public async Task<IEnumerable<Room>> GetEmptyRooms()
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).Where(r => r.Students.Count == 0).ToListAsync();
            return rooms;
        }

        public async Task<IEnumerable<Room>> GetFullRooms()
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).Where(r => r.Students.Count == r.Capacity).ToListAsync();
            return rooms;
        }

        public async Task<IEnumerable<Room>> GetPartlyOccupiedRooms()
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).Where(r => r.Students.Count > 0 && r.Students.Count < r.Capacity).ToListAsync();
            return rooms;
        }
    }
}
