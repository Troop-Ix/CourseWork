using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSUserRepository : IRepository<User>
    {
        protected readonly MSDormitoryDatabase _db;

        public MSUserRepository(MSDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _db.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserID == id);
            return user;
        }

        public async Task Create(User user)
        {
            if (user != null)
            {
                await _db.InsertAsync(user);
            }
        }

        public async Task Update(User user, int id)
        {
            if (user != null)
            {
                user.UserID = id;
                await _db.UpdateAsync(user);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Users.Where(u => u.UserID == id).DeleteAsync();
        }
    }
}
