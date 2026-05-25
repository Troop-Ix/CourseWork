using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Async;
using System.Text;
using System.Threading.Tasks;
using DormitoryObjects.RepositoriesInterfaces;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей комнаты
    /// </summary>
    public class RoomRepository : IRoomRepository
    {
        protected readonly IDormitoryDatabase _db;

        public RoomRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о комнатах
        /// </summary>
        /// <returns>Получение всех данных о комнатах</returns>
        public async Task<IEnumerable<Room>> GetAll()
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).LoadWith(r => r.Inventory).OrderBy(r => r.RoomID).ToListAsync();
            return rooms;
        }
        /// <summary>
        /// Получение данных о комнате с заданным id
        /// </summary>
        /// <param name="id">id комнаты</param>
        /// <returns>Данные о комнате с заданным id</returns>
        public async Task<Room> GetById(int id)
        {
            var room = await _db.Rooms.LoadWith(r => r.Students).LoadWith(r => r.Inventory).FirstOrDefaultAsync(r => r.RoomID == id);
            return room;
        }
        /// <summary>
        /// Добавление комнаты
        /// </summary>
        /// <param name="room">Комната</param>
        /// <returns></returns>
        public async Task Create(Room room)
        {
            if (room != null)
            {
                await _db.InsertAsync(room);
            }
        }
        /// <summary>
        /// Обновление информации о комнате с указанным id
        /// </summary>
        /// <param name="room">Объект комнаты с новой информацией</param>
        /// <param name="id">id изменяемой комнаты</param>
        /// <returns></returns>
        public async Task Update(Room room, int id)
        {
            var oldRoom = await _db.Rooms.LoadWith(r => r.Students).LoadWith(r => r.Inventory).FirstOrDefaultAsync(r => r.RoomID == id);
            if (oldRoom != null)
            {
                oldRoom.Area = room.Area;
                oldRoom.Capacity = room.Capacity;
                oldRoom.Floor = room.Floor;
                oldRoom.Number = room.Number;
                await _db.UpdateAsync(oldRoom);
            }
        }
        /// <summary>
        /// Удаление комнаты с заданным id
        /// </summary>
        /// <param name="id">id комнаты</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.Rooms.Where(r => r.RoomID == id).DeleteAsync();
        }
    }
}
