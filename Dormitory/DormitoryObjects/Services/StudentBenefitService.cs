using DormitoryObjects.DTO;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления льготами студентов
    /// </summary>
    public class StudentBenefitService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public StudentBenefitService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех льгот студентов
        /// </summary>
        /// <returns>возврат всех льгот студентов</returns>
        public async Task<IEnumerable<StudentBenefitDTO>> GetStudentBenefits()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentBenefitRepository(db);
                var studentBenefits = await repo.GetAll();
                return studentBenefits.Select(s => s.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Добавить льготу студенту
        /// </summary>
        /// <param name="studentId">id студента, которому добавляется льгота</param>
        /// <param name="benefitID">id типа льготы, которая добавляется студенту</param>
        /// <param name="issueDate">Дата выдачи льготы</param>
        /// <returns></returns>
        /// <exception cref="Exception">Ошибка выбрасывается, если студент или льгота не найдены, или если у студента уже есть такая льготы</exception>
        public async Task SetBenefitForStudent(int studentId, int benefitID, DateTime issueDate)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateStudentBenefitRepository(db);
                var studentRepo = _repoFactory.CreateStudentAdvancedRepository(db);
                var benefitRepo = _repoFactory.CreateBenefitTypeRepository(db);

                var studentExists = await studentRepo.GetById(studentId) ?? throw new Exception("Студент не найден в базе данных");
                    var benefitExists = await benefitRepo.GetById(benefitID) ?? throw new Exception("Льгота не найдена в базе данных");
                    var allBenefits = await repo.GetAll(); 
                    var alreadyHasBenefit = allBenefits.Any(b => b.StudentID == studentId && b.BenefitID == benefitID);

                    if (alreadyHasBenefit)
                    {
                        throw new Exception("У этого студента уже есть данная льгота.");
                    }
                    var studentBenefit = new StudentBenefit { BenefitID = benefitID, StudentID = studentId, IssueDate = issueDate };
                    await repo.Create(studentBenefit);
            }
        }
        /// <summary>
        /// Удаление всех льгот у студента
        /// </summary>
        /// <param name="studentId">id студента, у которого удаляются льготы</param>
        /// <returns></returns>
        /// <exception cref="Exception">Выбрасывается ошибка, если студент не найден</exception>
        public async Task RemoveAllBenefitsFromStudent(int studentId)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentBenefitRepository(db);
                var studentRepo = _repoFactory.CreateStudentAdvancedRepository(db);

                var studentExists = await studentRepo.GetById(studentId) ?? throw new Exception("Студент не найден в базе данных");
                
                foreach(var studentbenefit in studentExists.StudentBenefits.ToList())
                {
                    await repo.Delete(studentbenefit.StudentBenefitID);
                }
            }
        }
        /// <summary>
        /// Получение льготы студента по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>льгота студента</returns>
        public async Task<StudentBenefitDTO> GetstudentBenefitById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentBenefitRepository(db);
                var studentBenefit = await repo.GetById(id);
                return studentBenefit.ToDTO();
            }
        }
    }
}
