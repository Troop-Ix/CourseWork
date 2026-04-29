using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class StudentsService
    {
        private readonly IDbFactory _factory;
        public StudentsService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<Student>> GetStudentsBySurname(string surname)
        {
            using (var db = _factory.Create())
            {
                var repo = new StudentAdvancedRepository(db);
                if (string.IsNullOrWhiteSpace(surname))
                {
                    return await repo.GetAll();
                }

                return await repo.GetStudentsBySurname(surname);
            }
        }
        public async Task<IEnumerable<Student>> GetDebtors()
        {
            using (var db = _factory.Create())
            {
                var repo = new StudentAdvancedRepository(db);
                return await repo.GetDebtors();
            }
        }
        public async Task EvictStudent(int studentId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new StudentAdvancedRepository(db);
                    var student = await repo.GetById(studentId) ?? throw new Exception("Студент не найден в базе данных");
                    student.RoomID = null;
                    await repo.Update(student, studentId);
            }
        }
        public async Task SetRoomForStudent(int studentId, int roomId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new StudentAdvancedRepository(db);
                    var roomRepo = new RoomAdvancedRepository(db);

                    var room = await roomRepo.GetById(roomId);
                    if (room == null || room.Students.Count >= room.Capacity)
                    {
                         throw new Exception("Не хватает мест в заданной комнате");
                    }
                    var student = await repo.GetById(studentId) ?? throw new Exception("Студент не найден в базе данных");


                    student.RoomID = roomId;
                    await repo.Update(student, studentId);
            }
        }
        public async Task<Student> GetStudentById(int id)
        {
            using (var db = _factory.Create())
            {
                var repo = new StudentAdvancedRepository(db);
                var student = await repo.GetById(id);
                return student;
            }
        }
        public async Task<IEnumerable<Student>> GetStudents()
        {
            using (var db = _factory.Create())
            {
                var repo = new StudentAdvancedRepository(db);
                var students = await repo.GetAll();
                return students;
            }
        }
    }
}
