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
    public class MSBenefitTypeRepository : IRepository<BenefitType>
    {
        private readonly MSDormitoryDatabase _db;

        public MSBenefitTypeRepository(MSDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<BenefitType>> GetAll()
        {
            var benefitTypes = await _db.BenefitTypes.ToListAsync();
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
            if (benefitType != null)
            {
                benefitType.BenefitID = id;
                await _db.UpdateAsync(benefitType);
            }
        }

        public async Task Delete(int id)
        {
            await _db.BenefitTypes.Where(bt => bt.BenefitID == id).DeleteAsync();
        }
    }
}
