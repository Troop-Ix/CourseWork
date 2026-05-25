using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
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
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей пользователи
    /// </summary>
    public class UserRepository : IUserRepository
    {
        protected readonly IDormitoryDatabase _db;

        public UserRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о пользователях
        /// </summary>
        /// <returns>Получение всех данных о пользователях</returns>
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _db.Users.OrderBy(u => u.UserID).ToListAsync();
            return users;
        }
        /// <summary>
        /// Получение данных о пользователе с заданным id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns>Данные о пользователе с заданным id</returns>
        public async Task<User> GetById(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserID == id);
            return user;
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        public async Task Create(User user)
        {
            if (user != null)
            {
                await _db.InsertAsync(user);
            }
        }
        /// <summary>
        /// Обновление информации о пользователе с указанным id
        /// </summary>
        /// <param name="user">Объект пользователя с новой информацией</param>
        /// <param name="id">id изменяемого пользователя</param>
        /// <returns></returns>
        public async Task Update(User user, int id)
        {
            var oldUser = await _db.Users.FirstOrDefaultAsync(u => u.UserID == id);
            if (oldUser != null)
            {
                oldUser.Login = user.Login;
                oldUser.Name = user.Name;
                oldUser.Surname = user.Surname;
                oldUser.Middlename = user.Middlename;
                oldUser.Type = user.Type;
                await _db.UpdateAsync(oldUser);
            }
        }
        /// <summary>
        /// Удаление пользователя с заданным id
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.Users.Where(u => u.UserID == id).DeleteAsync();
        }
    }
}
