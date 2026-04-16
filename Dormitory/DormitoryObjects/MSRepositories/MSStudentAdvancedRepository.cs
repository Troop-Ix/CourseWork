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
    public class MSStudentAdvancedRepository : MSStudentRepository, IStudentAdvancedRepository
    {
        public MSStudentAdvancedRepository(MSDormitoryDatabase db) : base(db) { }

        public async Task<IEnumerable<Student>> GetStudentsBySurname(string surname)
        {
            var students = await _db.Students.Where(s => s.Surname.Contains(surname)).ToListAsync();
            return students;
        }
        public async Task<IEnumerable<Student>> GetDebtors()
        {
            var debtors = await _db.Students.LoadWith(s => s.Payments).Where(s => s.Payments.Any(p => p.PaidAmount < p.AmountDue)).ToListAsync();
            return debtors;
        }
    }
}
