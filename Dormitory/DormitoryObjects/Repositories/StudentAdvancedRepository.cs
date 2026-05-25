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
    /// <summary>
    /// Паттерн "Репозиторий", реализующий специфичные операции с таблицей студентов
    /// </summary>
    public class StudentAdvancedRepository : StudentRepository, IStudentAdvancedRepository
    {
        public StudentAdvancedRepository(IDormitoryDatabase db) : base(db) { }
        /// <summary>
        /// Получение записей студентов, у которых фамилия содержит введённые символы
        /// </summary>
        /// <param name="surname">Символы для поиска студентов</param>
        /// <returns>Записи студентов</returns>
        public async Task<IEnumerable<Student>> GetStudentsBySurname(string surname)
        {
            var students = await _db.Students.Where(s => s.Surname.StartsWith(surname)).LoadWith(s => s.Payments).LoadWith(s => s.Room).LoadWith(s => s.StudentBenefits).ThenLoad(b => b.BenefitType).ToListAsync();
           return students;
        }
        /// <summary>
        /// Получение записей студентов, у которых имеются неоплаченные долги
        /// </summary>
        /// <returns>Записи студентов</returns>
        public async Task<IEnumerable<Student>> GetDebtors()
        {
            var debtors = await _db.Students.LoadWith(s => s.Payments).LoadWith(s => s.Room).LoadWith(s => s.StudentBenefits).ThenLoad(b => b.BenefitType).Where(s => s.Payments.Any(p => p.PaidAmount < p.AmountDue)).ToListAsync();
            return debtors;
        }
    }
}
