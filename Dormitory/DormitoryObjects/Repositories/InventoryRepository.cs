using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class InventoryRepository : IRepository<Inventory>
    {
        protected readonly IDormitoryDatabase _db;

        public InventoryRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            var items = await _db.Inventory.ToListAsync();
            return items;
        }

        public async Task<Inventory> GetById(int id)
        {
            var item = await _db.Inventory.FirstOrDefaultAsync(i => i.ItemID == id);
            return item;
        }

        public async Task Create(Inventory item)
        {
            if (item != null)
            {
                await _db.InsertAsync(item);
            }
        }

        public async Task Update(Inventory item, int id)
        {
            var oldItem = await GetById(id);
            if (oldItem != null)
            {
                oldItem.Name = item.Name;
                oldItem.Condition = item.Condition;
                oldItem.RoomID = item.RoomID;
                oldItem.PurchaseDate = item.PurchaseDate;
                await _db.UpdateAsync(oldItem);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Inventory.Where(i => i.ItemID == id).DeleteAsync();
        }
    }
}
