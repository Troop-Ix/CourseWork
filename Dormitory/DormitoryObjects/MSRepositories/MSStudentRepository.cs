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
    public class MSStudentRepository : IRepository<Student>
    {
        protected readonly MSDormitoryDatabase _db;

        public MSStudentRepository(MSDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            var students = await _db.Students.ToListAsync();
            return students;
        }

        public async Task<Student> GetById(int id)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            return student;
        }

        public async Task Create(Student student)
        {
            if (student != null)
            {
                await _db.InsertAsync(student);
            }
        }

        public async Task Update(Student student, int id)
        {
            if (student != null)
            {
                student.StudentID = id;
                await _db.UpdateAsync(student);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Students.Where(s => s.StudentID == id).DeleteAsync();
        }
    }
}
