using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public interface IUserAdvancedRepository : IRepository<User>
    {
        Task<User> GetByLogin(string login);
    }
}
