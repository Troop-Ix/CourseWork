using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class InventoryService
    {
        private readonly IDbFactory _factory;
        public InventoryService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            using (var db = _factory.Create())
            {
                var repo = new InventoryRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task AddInventory(int typeID, int stateID, DateTime purchaseDate)
        {
            using (var db = _factory.Create())
            {
                    var repo = new InventoryRepository(db);
                    var repoInventoryTypes = new InventoryTypeRepository(db);
                    var repoInventoryStates = new InventoryStatesRepository(db);

                    var type = await repoInventoryTypes.GetById(typeID) ?? throw new Exception("Тип инвентаря не найден в базе данных");

                    var state = await repoInventoryStates.GetById(stateID) ?? throw new Exception("Состояние инвентаря не найдено в базе данных");


                    var item = new Inventory { RoomID = null, TypeID=typeID, StateID = stateID, PurchaseDate = purchaseDate };
                    await repo.Create(item);
            }
        }
        public async Task UpdateInventoryCondition(int itemId, int newState)
        {
            using (var db = _factory.Create())
            {
                    var repo = new InventoryRepository(db);
                    var item = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных"); 

                    if (newState == 2 || newState == 3)
                    {
                        item.RoomID = null;
                    }
                    item.StateID = newState;
                    await repo.Update(item, itemId);
            }
        }
        public async Task RemoveInventory(int itemId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new InventoryRepository(db);
                    await repo.Delete(itemId);
            }
        }
        public async Task SetInventoryForRoom(int itemId, int roomId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new InventoryRepository(db);
                    var roomRepo = new RoomAdvancedRepository(db);

                    var room = await roomRepo.GetById(roomId) ?? throw new Exception("Комната не найдена в базе данных");

                    var inventory = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных");

                    if (inventory.StateID == 3)
                    {
                        throw new Exception("Нельзя назначить предмет, который в ремонте");
                    }
                    inventory.RoomID = roomId;
                    await repo.Update(inventory, itemId);
            }
        }
        public async Task RemoveInventoryFromRoom(int itemId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new InventoryRepository(db);
                    var inventory = await repo.GetById(itemId) ?? throw new Exception("Предмет не найден в базе данных");
                    inventory.RoomID = null;
                    inventory.StateID = 2;
                    await repo.Update(inventory, itemId);
            }
        }
    }
}
