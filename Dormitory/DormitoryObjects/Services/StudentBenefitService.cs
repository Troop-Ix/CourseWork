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
        public async Task SetBenefitForStudent(int studentID, int benefitID, DateTime issueDate)
        {
            using (var db = _factory.Create())
            {
                    var repo = new StudentBenefitRepository(db);
                    var studentRepo = new StudentAdvancedRepository(db);
                    var benefitRepo = new BenefitTypeRepository(db);

                    var studentExists = await studentRepo.GetById(studentID) ?? throw new Exception("Студент не найден в базе данных");
                    var benefitExists = await benefitRepo.GetById(benefitID) ?? throw new Exception("Льгота не найдена в базе данных");
                    var studentBenefit = new StudentBenefit { BenefitID = benefitID, StudentID = studentID, IssueDate = issueDate };
                    await repo.Create(studentBenefit);
            }
        }
        public async Task RemoveBenefitFromStudent(int studentBenefitId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new StudentBenefitRepository(db);

                    await repo.Delete(studentBenefitId);
            }
        }
    }
}
