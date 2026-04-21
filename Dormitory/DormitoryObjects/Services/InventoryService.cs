using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
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
        public async Task<bool> AddInventory(string name, string condition, DateTime purchaseDate)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new InventoryRepository(db);
                    var item = new Inventory { RoomID = null, Name = name, Condition = condition, PurchaseDate = purchaseDate };
                    await repo.Create(item);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> UpdateInventoryCondition(int itemId, string condition)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new InventoryRepository(db);
                    var item = await repo.GetById(itemId);
                    if (item == null)
                        return false;
                    item.Condition = condition;
                    await repo.Update(item, itemId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> RemoveInventory(int itemId)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new InventoryRepository(db);
                    await repo.Delete(itemId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> SetInventoryForRoom(int itemId, int roomId)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new InventoryRepository(db);
                    var roomRepo = new RoomAdvancedRepository(db);

                    var room = await roomRepo.GetById(roomId);
                    if (room == null)
                    {
                        return false;
                    }
                    var inventory = await repo.GetById(itemId);
                    if (inventory == null)
                    {
                        return false;
                    }
                    inventory.RoomID = roomId;
                    await repo.Update(inventory, itemId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> RemoveInventoryFromRoom(int itemId)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new InventoryRepository(db);
                    var inventory = await repo.GetById(itemId);

                    if (inventory == null)
                    {
                        return false;
                    }
                    inventory.RoomID = null;
                    await repo.Update(inventory, itemId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
