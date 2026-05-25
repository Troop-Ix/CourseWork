using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.RepositoriesInterfaces
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей комнаты
    /// </summary>
    public interface IRoomRepository: IRepository<Room>
    {
    }
}
