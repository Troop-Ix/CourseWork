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
    public class InventoryTypesService
    {
        private readonly IDbFactory _factory;
        public InventoryTypesService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<InventoryTypes>> GetInventoryTypes()
        {
            using (var db = _factory.Create())
            {
                var repo = new InventoryTypeRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task<IEnumerable<int>> GetInventoryTypesID()
        {
            using (var db = _factory.Create())
            {
                var repo = new InventoryTypeRepository(db);
                var types= await repo.GetAll();
                var typesID = types.Select(t => t.TypeID);
                return typesID;
            }
        }
    }
}
