using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class StudentBenefitService
    {
        private readonly IDbFactory _factory;
        public StudentBenefitService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<StudentBenefit>> GetStudentBenefits()
        {
            using (var db = _factory.Create())
            {
                var repo = new StudentBenefitRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task<bool> SetBenefitForStudent(int studentID, int benefitID, DateTime issueDate)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new StudentBenefitRepository(db);
                    var studentRepo = new StudentAdvancedRepository(db);
                    var benefitRepo = new BenefitTypeRepository(db);

                    var studentExists = await studentRepo.GetById(studentID);
                    if (studentExists == null)
                    {
                        return false;
                    }

                    var benefitExists = await benefitRepo.GetById(benefitID);
                    if (benefitExists == null)
                    {
                        return false;
                    }
                    var studentBenefit = new StudentBenefit { BenefitID = benefitID, StudentID = studentID, IssueDate = issueDate };
                    await repo.Create(studentBenefit);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> RemoveBenefitFromStudent(int studentBenefitId)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new StudentBenefitRepository(db);

                    await repo.Delete(studentBenefitId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
