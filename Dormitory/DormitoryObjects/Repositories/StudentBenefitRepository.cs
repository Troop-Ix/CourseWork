using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей льготы студентов
    /// </summary>
    public class StudentBenefitRepository : IStudentBenefitRepository
    {
        protected readonly IDormitoryDatabase _db;

        public StudentBenefitRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о льготах студентов
        /// </summary>
        /// <returns>Получение всех данных о льготах студентов</returns>
        public async Task<IEnumerable<StudentBenefit>> GetAll()
        {
            var studentBenefits = await _db.StudentBenefits.LoadWith(sb => sb.Student).LoadWith(sb => sb.BenefitType).OrderBy(sb => sb.StudentBenefitID).ToListAsync();
            return studentBenefits;
        }
        /// <summary>
        /// Получение данных о льготе студента с заданным id
        /// </summary>
        /// <param name="id">id льготы студента</param>
        /// <returns>Данные о льготе студента с заданным id</returns>
        public async Task<StudentBenefit> GetById(int id)
        {
            var studentBenefit = await _db.StudentBenefits.LoadWith(sb => sb.Student).LoadWith(sb => sb.BenefitType).FirstOrDefaultAsync(sb => sb.StudentBenefitID == id);
            return studentBenefit;
        }
        /// <summary>
        /// Добавление льготы студенту
        /// </summary>
        /// <param name="studentBenefit">Льгота студента</param>
        /// <returns></returns>
        public async Task Create(StudentBenefit studentBenefit)
        {
            if (studentBenefit != null)
            {
                await _db.InsertAsync(studentBenefit);
            }
        }
        /// <summary>
        /// Обновление информации о льготе студента с указанным id
        /// </summary>
        /// <param name="studentBenefit">Объект льготы студента с новой информацией</param>
        /// <param name="id">id изменяемой льготы студента</param>
        /// <returns></returns>
        public async Task Update(StudentBenefit studentBenefit, int id)
        {
            var oldStudentBenefit = await _db.StudentBenefits.LoadWith(sb => sb.Student).LoadWith(sb => sb.BenefitType).FirstOrDefaultAsync(sb => sb.StudentBenefitID == id);
            if (oldStudentBenefit != null)
            {
                oldStudentBenefit.StudentID = studentBenefit.StudentID;
                oldStudentBenefit.BenefitID = studentBenefit.BenefitID;
                oldStudentBenefit.IssueDate = studentBenefit.IssueDate;
                await _db.UpdateAsync(oldStudentBenefit);
            }
        }
        /// <summary>
        /// Удаление льготы студента с заданным id
        /// </summary>
        /// <param name="id">id льготы студента</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.StudentBenefits.Where(sb => sb.StudentBenefitID == id).DeleteAsync();
        }
    }
}
