using DormitoryObjects.DTO;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления студентами
    /// </summary>
    public class StudentsService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public StudentsService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение либо всех студентов, либо студентов фамилия, которых содержит введённые символы
        /// </summary>
        /// <param name="surname">символы, содержащиеся в фамилиях искомых студентов</param>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDTO>> GetStudentsBySurname(string surname)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentAdvancedRepository(db);
                var students = string.IsNullOrWhiteSpace(surname) ? await repo.GetAll() : await repo.GetStudentsBySurname(surname);
                return students.Select(s => s.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение списка должников
        /// </summary>
        /// <returns>Список должников</returns>
        public async Task<IEnumerable<StudentDTO>> GetDebtors()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentAdvancedRepository(db);
                var debtors = await repo.GetDebtors();
                var debtorsDTO = debtors.Select(s => s.ToDTO()).ToList();
                return debtorsDTO;
            }
        }
        /// <summary>
        /// Выселение студента из комнаты
        /// </summary>
        /// <param name="studentId">id студента, которого выселяют из комнаты</param>
        /// <returns></returns>
        /// <exception cref="Exception">Ошибка выбрасывается, если студент не найден</exception>
        public async Task EvictStudent(int studentId)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateStudentAdvancedRepository(db);
                var student = await repo.GetById(studentId) ?? throw new Exception("Студент не найден в базе данных");
                    student.RoomID = null;
                    await repo.Update(student, studentId);
            }
        }
        /// <summary>
        /// Заселение студента в комнату
        /// </summary>
        /// <param name="studentId">id студента, которого заселяют</param>
        /// <param name="roomId">id комнаты, в которую заселяют студента</param>
        /// <returns></returns>
        /// <exception cref="Exception">Ошибка выбрасывается, если в комнате не хватает мест, или если студент не найден</exception>
        public async Task SetRoomForStudent(int studentId, int roomId)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreateStudentAdvancedRepository(db);
                var roomRepo = _repoFactory.CreateRoomRepository(db);

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
        /// <summary>
        /// Получение студента по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>студент</returns>
        public async Task<StudentDTO> GetStudentById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentAdvancedRepository(db);
                var student = await repo.GetById(id);
                var studentDTO = student.ToDTO();
                return studentDTO;
            }
        }
        /// <summary>
        /// Получение  всех студентлв
        /// </summary>
        /// <returns>возврат всех студентов</returns>
        public async Task<IEnumerable<StudentDTO>> GetStudents()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateStudentAdvancedRepository(db);
                var students = await repo.GetAll();
                var studentDTO = students.Select(s => s.ToDTO()).ToList();
                return studentDTO;
            }
        }
    }
}
