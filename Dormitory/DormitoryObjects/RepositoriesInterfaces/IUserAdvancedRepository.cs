using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий специфичные операции с таблицей пользователей
    /// </summary>
    public interface IUserAdvancedRepository : IRepository<User>
    {
        /// <summary>
        /// Получение записи пользователя по введённому логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns></returns>
        Task<User> GetByLogin(string login);
    }
}
