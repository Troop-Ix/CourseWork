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
    /// Класс-сервис для управления пользователями
    /// </summary>
    public class UserService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public UserService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Пользователь системы</returns>
        public async Task<User> GetUserByLogin(string login)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateUserAdvancedRepository(db);
                return await repo.GetByLogin(login);
            }
        }
        /// <summary>
        /// Получение пользователя по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>Пользователь системы</returns>
        public async Task<User> GetUserById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateUserAdvancedRepository(db);
                var user = await repo.GetById(id);
                return user;
            }
        }
    }
}
