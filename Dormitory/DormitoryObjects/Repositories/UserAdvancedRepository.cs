using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий специфичные операции с таблицей пользователей
    /// </summary>
    public class UserAdvancedRepository : UserRepository, IUserAdvancedRepository
    {
        public UserAdvancedRepository(IDormitoryDatabase db) : base(db) { }
        /// <summary>
        /// Получение записи пользователя по введённому логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns></returns>
        public async Task<User> GetByLogin(string login)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Login == login);
            return user;
        }
    }
}
