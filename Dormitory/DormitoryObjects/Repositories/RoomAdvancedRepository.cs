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
    /// <summary>
    /// Паттерн "Репозиторий", реализующий специфичные операции с таблицей комнаты
    /// </summary>
    public class RoomAdvancedRepository : RoomRepository, IRoomAdvancedRepository
    {
        public RoomAdvancedRepository(IDormitoryDatabase db) : base(db) { }
        /// <summary>
        /// Получение записей комнат с заданным количеством свободных мест
        /// </summary>
        /// <param name="roomsCount">Количество свободных мест</param>
        /// <returns>Записи комнат</returns>
        public async Task<IEnumerable<Room>> FilterRoomByOccupancy(int studentsCount)
        {
            if (studentsCount >= 0)
            {
                var rooms = await _db.Rooms.LoadWith(r => r.Students).LoadWith(r => r.Inventory).Where(r => r.Capacity - r.Students.Count() == studentsCount).ToListAsync();
                rooms=rooms.OrderBy(r=>r.Floor).ThenBy(r=>r.Number).ToList();
                return rooms;
            }
            else
            {
                return Enumerable.Empty<Room>();
            }
        }
        /// <summary>
        /// Получение записей комнат с заданного этажа общежития
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <returns>Записи комнат</returns>
        public async Task<IEnumerable<Room>> GetRoomsFromFloor(int floor)
        {
            var rooms = await _db.Rooms.LoadWith(r => r.Students).LoadWith(r => r.Inventory).Where(r => r.Floor == floor).ToListAsync();
            return rooms;
        }
        /// <summary>
        /// Получение номеров этажей в общежитии
        /// </summary>
        /// <returns>Номера этажей</returns>
        public async Task<IEnumerable<int>> GetFloors()
        {
            var floors = await _db.Rooms.Select(r => r.Floor).Distinct().ToListAsync();
            return floors;
        }
        /// <summary>
        /// Получение номеров комнат с заданного этажа общежития
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <returns>Номер комнат с этажа</returns>
        public async Task<IEnumerable<int>> GetNumbersFromFloor(int floor)
        {
            var numbers = await _db.Rooms.Where(r=>r.Floor == floor).Select(r=>r.Number).ToListAsync();
            return numbers;
        }
        /// <summary>
        /// Получение записи комнаты с заданного этаже и с заданным номером
        /// </summary>
        /// <param name="floor">Номер этажа</param>
        /// <param name="number">Номер комнаты</param>
        /// <returns>Запись комнаты с заданного этажа и с заданным номером</returns>
        public async Task<Room> GetRoomByFloorAndNumber(int floor, int number)
        {
            var room = await _db.Rooms.FirstOrDefaultAsync(r=>r.Floor==floor && r.Number==number);
            return room;
        }
    }
}
