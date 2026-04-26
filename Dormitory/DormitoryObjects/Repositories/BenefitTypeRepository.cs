using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Async;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class BenefitTypeRepository : IRepository<BenefitType>
    {
        private readonly IDormitoryDatabase _db;

        public BenefitTypeRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<BenefitType>> GetAll()
        {
            var benefitTypes = await _db.BenefitTypes.OrderBy(b => b.BenefitID).ToListAsync();
            return benefitTypes;
        }

        public async Task<BenefitType> GetById(int id)
        {
            var benefitType = await _db.BenefitTypes.FirstOrDefaultAsync(bt => bt.BenefitID == id);
            return benefitType;
        }

        public async Task Create(BenefitType benefitType)
        {
            if (benefitType != null)
            {
                await _db.InsertAsync(benefitType);
            }
        }

        public async Task Update(BenefitType benefitType, int id)
        {
            var oldBenefitType = await GetById(id);
            if (oldBenefitType != null)
            {
                oldBenefitType.Name = benefitType.Name;
                oldBenefitType.Description = benefitType.Description;
                await _db.UpdateAsync(oldBenefitType);
            }
        }

        public async Task Delete(int id)
        {
            await _db.BenefitTypes.Where(bt => bt.BenefitID == id).DeleteAsync();
        }
    }
}
