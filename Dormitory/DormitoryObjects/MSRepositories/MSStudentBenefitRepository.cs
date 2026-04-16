using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSStudentBenefitRepository : IRepository<StudentBenefit>
    {
        protected readonly MSDormitoryDatabase _db;

        public MSStudentBenefitRepository(MSDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<StudentBenefit>> GetAll()
        {
            var studentBenefits = await _db.StudentBenefits.ToListAsync();
            return studentBenefits;
        }

        public async Task<StudentBenefit> GetById(int id)
        {
            var studentBenefit = await _db.StudentBenefits.LoadWith(sb => sb.Student).LoadWith(sb => sb.BenefitType).FirstOrDefaultAsync(sb => sb.StudentBenefitID == id);
            return studentBenefit;
        }

        public async Task Create(StudentBenefit studentBenefit)
        {
            if (studentBenefit != null)
            {
                await _db.InsertAsync(studentBenefit);
            }
        }

        public async Task Update(StudentBenefit studentBenefit, int id)
        {
            if (studentBenefit != null)
            {
                studentBenefit.StudentBenefitID = id;
                await _db.UpdateAsync(studentBenefit);
            }
        }

        public async Task Delete(int id)
        {
            await _db.StudentBenefits.Where(sb => sb.StudentBenefitID == id).DeleteAsync();
        }
    }
}
