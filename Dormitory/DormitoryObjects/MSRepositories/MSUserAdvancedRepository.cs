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
    public class MSUserAdvancedRepository : MSUserRepository, IUserAdvancedRepository
    {
        public MSUserAdvancedRepository(MSDormitoryDatabase db) : base(db) { }

        public async Task<User> GetByLogin(string login)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Login == login);
            return user;
        }
    }
}
