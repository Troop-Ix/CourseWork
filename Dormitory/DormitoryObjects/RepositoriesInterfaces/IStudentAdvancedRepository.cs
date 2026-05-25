using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий специфичные операции с таблицей студентов
    /// </summary>
    public interface IStudentAdvancedRepository : IRepository<Student>
    {
        /// <summary>
        /// Получение записей студентов, у которых фамилия содержит введённые символы
        /// </summary>
        /// <param name="surname">Символы для поиска студентов</param>
        /// <returns>Записи студентов</returns>
        Task<IEnumerable<Student>> GetStudentsBySurname(string surname);
        /// <summary>
        /// Получение записей студентов, у которых имеются неоплаченные долги
        /// </summary>
        /// <returns>Записи студентов</returns>
        Task<IEnumerable<Student>> GetDebtors();
    }
}
