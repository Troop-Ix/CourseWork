using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
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
    }
}
