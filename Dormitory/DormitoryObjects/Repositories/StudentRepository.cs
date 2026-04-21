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
    public class StudentRepository : IRepository<Student>
    {
        protected readonly IDormitoryDatabase _db;

        public StudentRepository(IDormitoryDatabase db)
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
            var oldStudent = await GetById(id);
            if (oldStudent != null)
            {
                oldStudent.Name = student.Name;
                oldStudent.Surname = student.Surname;
                oldStudent.Middlename = student.Middlename;
                oldStudent.Birthdate = student.Birthdate;
                oldStudent.PhoneNumber = student.PhoneNumber;
                oldStudent.Faculty = student.Faculty;
                oldStudent.Group = student.Group;
                oldStudent.RoomID = student.RoomID;
                await _db.UpdateAsync(oldStudent);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Students.Where(s => s.StudentID == id).DeleteAsync();
        }
    }
}
