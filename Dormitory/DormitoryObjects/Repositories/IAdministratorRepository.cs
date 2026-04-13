using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public interface IAdministratorRepository : IGeneralRepository
    {
        Task<bool> AddInventory(Inventory item);
        Task<bool> RemoveInventory(int itemId);
        Task<bool> UpdateInventoryCondition(int itemId, string condition);

        Task<IEnumerable<Student>> GetDebtors();
    }
}
