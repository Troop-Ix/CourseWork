using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSAdministratorRepository : MSRepository, IAdministratorRepository
    {
        public MSAdministratorRepository(string connectionString) : base(connectionString) { }

        public async Task<bool> AddInventory(Inventory item)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    await db.InsertAsync(item);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Student>> GetDebtors()
        {
            using (var db = new DataConnection(options))
            {
                var debtors = await db.GetTable<Student>().LoadWith(s => s.Payments).Where(s => s.Payments.Any(p => p.PaidAmount < p.AmountDue)).ToListAsync();
                return debtors;
            }
        }

        public async Task<bool> RemoveInventory(int itemId)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var exists = await db.GetTable<Inventory>().AnyAsync(i => i.ItemID == itemId);

                    if (!exists) { return false; }
                    await db.GetTable<Inventory>().Where(i => i.ItemID == itemId).DeleteAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateInventoryCondition(int itemId, string condition)
        {
            try
            {
                using (var db = new DataConnection(options))
                {
                    var exists = await db.GetTable<Inventory>().AnyAsync(i => i.ItemID == itemId);

                    if (!exists) { return false; }
                    await db.GetTable<Inventory>().Where(i => i.ItemID == itemId).Set(i => i.Condition, condition).UpdateAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
