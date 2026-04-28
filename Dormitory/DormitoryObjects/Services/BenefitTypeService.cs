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
    public class BenefitTypeService
    {
        private readonly IDbFactory _factory;
        public BenefitTypeService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<BenefitType>> GetBenefitTypes()
        {
            using (var db = _factory.Create())
            {
                var repo = new BenefitTypeRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task<IEnumerable<int>> GetBenefitsID()
        {
            using (var db = _factory.Create())
            {
                var repo = new BenefitTypeRepository(db);
                var types = await repo.GetAll();
                var typesID = types.Select(t => t.BenefitID);
                return typesID;
            }
        }
    }
}
