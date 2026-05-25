using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий специфичные операции с таблицей комнаты
    /// </summary>
    public interface IRoomAdvancedRepository : IRepository<Room>
    {
        /// <summary>
        /// Получение записей комнат с заданным количеством свободных мест
        /// </summary>
        /// <param name="roomsCount">Количество свободных мест</param>
        /// <returns>Записи комнат</returns>
        Task<IEnumerable<Room>> FilterRoomByOccupancy(int roomsCount);
        /// <summary>
        /// Получение записей комнат с заданного этажа общежития
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <returns>Записи комнат</returns>
        Task<IEnumerable<Room>> GetRoomsFromFloor(int floor);
        /// <summary>
        /// Получение номеров этажей в общежитии
        /// </summary>
        /// <returns>Номера этажей</returns>
        Task<IEnumerable<int>> GetFloors();
        /// <summary>
        /// Получение номеров комнат с заданного этажа общежития
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <returns>Номер комнат с этажа</returns>
        Task<IEnumerable<int>> GetNumbersFromFloor(int floor);
        /// <summary>
        /// Получение записи комнаты с заданного этаже и с заданным номером
        /// </summary>
        /// <param name="floor">Номер этажа</param>
        /// <param name="number">Номер комнаты</param>
        /// <returns>Запись комнаты с заданного этажа и с заданным номером</returns>
        Task<Room> GetRoomByFloorAndNumber(int floor, int number);
    }
}
