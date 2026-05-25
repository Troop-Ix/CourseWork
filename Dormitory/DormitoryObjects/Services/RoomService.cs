using DormitoryObjects.DTO;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления комнатами
    /// </summary>
    public class RoomService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public RoomService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех комнат
        /// </summary>
        /// <returns>возврат всех комнат</returns>
        public async Task<IEnumerable<RoomDTO>> GetRooms()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                var rooms = await repo.GetAll();
                return rooms.Select(r=>r.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение комнат с заданным количеством свободных мест
        /// </summary>
        /// <param name="freePlaces">Количество свободных мест</param>
        /// <returns>Список комнат с заданным количеством свободных мест</returns>
        public async Task<IEnumerable<RoomDTO>> GetFilteredRooms(int freePlaces)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                var filteredRooms = await repo.FilterRoomByOccupancy(freePlaces);
                return filteredRooms.Select(r => r.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение номеров этажей с комнатами в общежитии
        /// </summary>
        /// <returns>Номера этажей</returns>
        public async Task<IEnumerable<int>> GetFloors()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                return await repo.GetFloors();
            }
        }
        /// <summary>
        /// Получение номеров комнат на заданном этаже
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <returns>Номера комнат</returns>
        public async Task<IEnumerable<int>> GetNumbersFromFloor(int floor)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                return await repo.GetNumbersFromFloor(floor);
            }
        }
        /// <summary>
        /// Получение комнат с заданного этажа
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <returns>Комнаты на заданном этаже</returns>
        public async Task<IEnumerable<RoomDTO>> GetRoomsFromFloor(int floor)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                var rooms = await repo.GetRoomsFromFloor(floor);
                return rooms.Select(r => r.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение комнаты по этажу и номеру
        /// </summary>
        /// <param name="floor">Этаж общежития</param>
        /// <param name="number">Номер комнаты</param>
        /// <returns>Комната с заданным номером на заданном этаже</returns>
        public async Task<RoomDTO> GetRoomByFloorAndNumber(int floor, int number)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                var rooms = await repo.GetRoomByFloorAndNumber(floor, number);
                return rooms.ToDTO();
            }
        }
        /// <summary>
        /// Получение комнаты по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>комната</returns>
        public async Task<RoomDTO> GetRoomById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateRoomRepository(db);
                var room = await repo.GetById(id);
                return room.ToDTO();
            }
        }
    }
}
