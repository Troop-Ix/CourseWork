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
    public class MSInventoryRepository : IRepository<Inventory>
    {
        protected readonly MSDormitoryDatabase _db;

        public MSInventoryRepository(MSDormitoryDatabase db)
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
            if (item != null)
            {
                item.ItemID = id;
                await _db.UpdateAsync(item);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Inventory.Where(i => i.ItemID == id).DeleteAsync();
        }
    }
}
