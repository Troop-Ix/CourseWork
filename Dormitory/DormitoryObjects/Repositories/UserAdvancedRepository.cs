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
    public class UserAdvancedRepository : UserRepository, IUserAdvancedRepository
    {
        public UserAdvancedRepository(IDormitoryDatabase db) : base(db) { }

        public async Task<User> GetByLogin(string login)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Login == login);
            return user;
        }
    }
}
