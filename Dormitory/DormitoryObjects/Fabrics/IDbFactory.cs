using DormitoryObjects.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Fabrics
{
    /// <summary>
    /// Интерфейс для создания контекста базы данных
    /// </summary>
    public interface IDbFactory
    {
        /// <summary>
        /// Создание объекта базы данных на основе типа и строки подключения
        /// </summary>
        /// <returns>Возвращает объект базы данных в зависимости от переданного в конструктор типа</returns>
        IDormitoryDatabase Create();
    }
}
