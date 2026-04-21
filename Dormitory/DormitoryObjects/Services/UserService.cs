using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class UserService
    {
        private readonly IDbFactory _factory;
        public UserService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<User> GetUserByLogin(string login)
        {
            using (var db = _factory.Create())
            {
                var repo = new UserAdvancedRepository(db);
                return await repo.GetByLogin(login);
            }
        }
    }
}
