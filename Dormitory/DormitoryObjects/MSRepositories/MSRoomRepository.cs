using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Async;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSRoomRepository : IRepository<Room>
    {
        protected readonly MSDormitoryDatabase _db;

        public MSRoomRepository(MSDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Room>> GetAll()
        {
            var rooms = await _db.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> GetById(int id)
        {
            var room = await _db.Rooms.LoadWith(r => r.Students).LoadWith(r => r.Inventory).FirstOrDefaultAsync(r => r.RoomID == id);
            return room;
        }

        public async Task Create(Room room)
        {
            if (room != null)
            {
                await _db.InsertAsync(room);
            }
        }

        public async Task Update(Room room, int id)
        {
            if (room != null)
            {
                room.RoomID = id;
                await _db.UpdateAsync(room);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Rooms.Where(r => r.RoomID == id).DeleteAsync();
        }
    }
}
