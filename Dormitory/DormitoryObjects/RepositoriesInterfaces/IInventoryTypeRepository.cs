using DormitoryObjects.Entities;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.RepositoriesInterfaces
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей типы инвентаря
    /// </summary>
    public interface IInventoryTypeRepository: IRepository<InventoryType>
    {
    }
}
