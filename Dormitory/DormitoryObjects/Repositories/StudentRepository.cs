using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Async;
using System.Text;
using System.Threading.Tasks;
using DormitoryObjects.RepositoriesInterfaces;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей студенты
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        protected readonly IDormitoryDatabase _db;

        public StudentRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о студентах
        /// </summary>
        /// <returns>Получение всех данных о студентах</returns>
        public async Task<IEnumerable<Student>> GetAll()
        {
            var students = await _db.Students.LoadWith(s => s.Payments).LoadWith(s=>s.Room).LoadWith(s => s.StudentBenefits).ThenLoad(b => b.BenefitType).OrderBy(s => s.StudentID).ToListAsync();
            return students;
        }
        /// <summary>
        /// Получение данных о студенте с заданным id
        /// </summary>
        /// <param name="id">id студента</param>
        /// <returns>Данные о студенте с заданным id</returns>
        public async Task<Student> GetById(int id)
        {
            var student = await _db.Students.LoadWith(s => s.Payments).LoadWith(s => s.Room).LoadWith(s => s.StudentBenefits).ThenLoad(b => b.BenefitType).FirstOrDefaultAsync(s => s.StudentID == id);
            return student;
        }
        /// <summary>
        /// Добавление студента
        /// </summary>
        /// <param name="student">Студент</param>
        /// <returns></returns>
        public async Task Create(Student student)
        {
            if (student != null)
            {
                await _db.InsertAsync(student);
            }
        }
        /// <summary>
        /// Обновление информации о студенте с указанным id
        /// </summary>
        /// <param name="student">Объект студента с новой информацией</param>
        /// <param name="id">id изменяемого студента</param>
        /// <returns></returns>
        public async Task Update(Student student, int id)
        {
            var oldStudent = await _db.Students.LoadWith(s => s.Payments).LoadWith(s => s.Room).LoadWith(s => s.StudentBenefits).ThenLoad(b => b.BenefitType).FirstOrDefaultAsync(s => s.StudentID == id);
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
        /// <summary>
        /// Удаление студента с заданным id
        /// </summary>
        /// <param name="id">id студента</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.Students.Where(s => s.StudentID == id).DeleteAsync();
        }
    }
}
