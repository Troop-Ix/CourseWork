using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.RepositoriesInterfaces
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей пользователи
    /// </summary>
    public interface IUserRepository: IRepository<User>
    {
    }
}
