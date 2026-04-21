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
    public class UserRepository : IRepository<User>
    {
        protected readonly IDormitoryDatabase _db;

        public UserRepository(IDormitoryDatabase db)
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
            var oldUser = await GetById(id);
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

        public async Task Delete(int id)
        {
            await _db.Users.Where(u => u.UserID == id).DeleteAsync();
        }
    }
}
