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
    public class InventoryStatesRepository: IRepository<InventoryStates>
    {
        protected readonly IDormitoryDatabase _db;

        public InventoryStatesRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<InventoryStates>> GetAll()
        {
            return await _db.InventoryStates.OrderBy(i => i.StateID).ToListAsync();
        }

        public async Task<InventoryStates> GetById(int id)
        {
            return await _db.InventoryStates.FirstOrDefaultAsync(i => i.StateID == id);
        }

        public async Task Create(InventoryStates itemState)
        {
            if (itemState != null)
            {
                await _db.InsertAsync(itemState);
            }
        }

        public async Task Update(InventoryStates itemState, int id)
        {
            var oldItemState = await GetById(id);
            if (oldItemState != null)
            {
                oldItemState.Name = itemState.Name;
                await _db.UpdateAsync(oldItemState);
            }
        }

        public async Task Delete(int id)
        {
            await _db.InventoryStates.Where(i => i.StateID == id).DeleteAsync();
        }
    }
}
