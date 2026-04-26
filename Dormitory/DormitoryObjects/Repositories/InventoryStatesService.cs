using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public class InventoryStatesService
    {
        private readonly IDbFactory _factory;
        public InventoryStatesService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<InventoryStates>> GetInventoryStates()
        {
            using (var db = _factory.Create())
            {
                var repo = new InventoryStatesRepository(db);
                return await repo.GetAll();
            }
        }
    }
}
