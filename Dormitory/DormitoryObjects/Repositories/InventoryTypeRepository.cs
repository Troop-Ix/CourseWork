using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public class InventoryTypeRepository: IRepository<InventoryTypes>
    {
        protected readonly IDormitoryDatabase _db;

        public InventoryTypeRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<InventoryTypes>> GetAll()
        {
            return await _db.InventoryTypes.OrderBy(i => i.TypeID).ToListAsync();
        }

        public async Task<InventoryTypes> GetById(int id)
        {
            return await _db.InventoryTypes.FirstOrDefaultAsync(i => i.TypeID == id);
        }

        public async Task Create(InventoryTypes itemType)
        {
            if (itemType != null)
            {
                await _db.InsertAsync(itemType);
            }
        }

        public async Task Update(InventoryTypes itemType, int id)
        {
            var oldItemType = await GetById(id);
            if (oldItemType != null)
            {
               oldItemType.Name = itemType.Name;
               await _db.UpdateAsync(oldItemType);
            }
        }

        public async Task Delete(int id)
        {
            await _db.InventoryTypes.Where(i => i.TypeID == id).DeleteAsync();
        }
    }
}
