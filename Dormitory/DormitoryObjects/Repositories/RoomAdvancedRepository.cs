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
    public class RoomAdvancedRepository : RoomRepository, IRoomAdvancedRepository
    {
        public RoomAdvancedRepository(IDormitoryDatabase db) : base(db) { }

        public async Task<IEnumerable<Room>> FilterRoomByOccupancy(int studentsCount)
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).Where(r =>r.Capacity-r.Students.Count() == studentsCount).ToListAsync();
            return rooms;
        }

        public async Task<IEnumerable<Room>> GetRoomsFromFloor(int floor)
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).Where(r => r.Floor == floor).ToListAsync();
            return rooms;
        }
        public async Task<IEnumerable<int>> GetFloors()
        {
            var floors = await _db.Rooms.Select(r => r.Floor).Distinct().ToListAsync();
            return floors;
        }
        public async Task<IEnumerable<int>> GetNumbersFromFloor(int floor)
        {
            var numbers = await _db.Rooms.Where(r=>r.Floor == floor).Select(r=>r.Number).ToListAsync();
            return numbers;
        }
        public async Task<Room> GetRoomByFloorAndNumber(int floor, int number)
        {
            var room = await _db.Rooms.FirstOrDefaultAsync(r=>r.Floor==floor && r.Number==number);
            return room;
        }
    }
}
