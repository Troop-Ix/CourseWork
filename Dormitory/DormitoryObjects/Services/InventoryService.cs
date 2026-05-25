using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления инвентарём
    /// </summary>
    public class InventoryService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public InventoryService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех предметов 
        /// </summary>
        /// <returns>возврат всех предметов</returns>
        public async Task<IEnumerable<InventoryDTO>> GetInventory()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryRepository(db);
                var inventory = await repo.GetAll();
                return inventory.Select(i => i.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Добавление предмета инвентаря
        /// </summary>
        /// <param name="typeID">id типа инвентаря</param>
        /// <param name="stateID">id состояния инвентаря</param>
        /// <param name="purchaseDate">Дата приобретения предмета </param>
        /// <returns></returns>
        /// <exception cref="Exception">Выбрасывает ошибку, если не найден тип или состояние инвентаря</exception>
        public async Task AddInventory(int typeID, int stateID, DateTime purchaseDate)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateInventoryRepository(db);
                var repoInventoryTypes = _repoFactory.CreateInventoryTypeRepository(db);
                var repoInventoryStates = _repoFactory.CreateInventoryStateRepository(db);

                var type = await repoInventoryTypes.GetById(typeID) ?? throw new Exception("Тип инвентаря не найден в базе данных");

                    var state = await repoInventoryStates.GetById(stateID) ?? throw new Exception("Состояние инвентаря не найдено в базе данных");


                    var item = new Inventory { RoomID = null, TypeID=typeID, StateID = stateID, PurchaseDate = purchaseDate };
                    await repo.Create(item);
            }
        }
        /// <summary>
        /// Обновление состояния предмета инвентаря
        /// </summary>
        /// <param name="itemId">id предмета инвентаря, который обновляется</param>
        /// <param name="newState">id состояния инвентаря</param>
        /// <returns></returns>
        /// <exception cref="Exception">Выбрасывает ошибку, если не найден предмет</exception>
        public async Task UpdateInventoryCondition(int itemId, int newState)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateInventoryRepository(db);
                var item = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных"); 

                    if (newState == 3 || newState == 4)
                    {
                        item.RoomID = null;
                    }
                    item.StateID = newState;
                    await repo.Update(item, itemId);
            }
        }
        /// <summary>
        /// Удаление предмета инвентаря
        /// </summary>
        /// <param name="itemId">id предмета инвентаря, который удаляется</param>
        /// <returns></returns>
        /// <exception cref="Exception">Выбрасывает ошибку, если не найден предмет</exception>
        public async Task RemoveInventory(int itemId)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryRepository(db);
                var inventory = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных");
                await repo.Delete(itemId);
            }
        }
        /// <summary>
        /// Назначение предмета в комнату
        /// </summary>
        /// <param name="itemId">id предмета инвентаря, который назначается</param>
        /// <param name="roomId">id комнаты, в которую назначается предмет</param>
        /// <returns></returns>
        /// <exception cref="Exception">Ошибка выпадет либо, если комната или предмет не найден, либо, если предмет имеет состояние "в ремонте" или "списан"</exception>
        public async Task SetInventoryForRoom(int itemId, int roomId)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateInventoryRepository(db);
                var roomRepo = _repoFactory.CreateRoomRepository(db);

                var room = await roomRepo.GetById(roomId) ?? throw new Exception("Комната не найдена в базе данных");

                    var inventory = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных");

                    if (inventory.StateID == 3)
                    {
                        throw new Exception("Нельзя назначить предмет, который в ремонте");
                    }
                    if (inventory.StateID == 4)
                    {
                        throw new Exception("Нельзя назначить предмет, который списан");
                    }
                    inventory.RoomID = roomId;
                    await repo.Update(inventory, itemId);
            }
        }
        /// <summary>
        /// Снять предмет с комнаты
        /// </summary>
        /// <param name="itemId">id предмета инвентаря, который снимается</param>
        /// <returns></returns>
        /// <exception cref="Exception">Выбрасывает ошибку, если не найден предмет</exception>
        public async Task RemoveInventoryFromRoom(int itemId)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateInventoryRepository(db);
                var inventory = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных");
                    inventory.RoomID = null;
                    await repo.Update(inventory, itemId);
            }
        }
        /// <summary>
        /// Получение предмета инвентаря по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>предмет инвентаря</returns>
        public async Task<InventoryDTO> GetInventoryById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryRepository(db);
                var item = await repo.GetById(id);
                return item.ToDTO();
            }
        }
    }
}
