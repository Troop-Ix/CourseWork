using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Получение всех данных указанной сущности
        /// </summary>
        /// <returns>Получение всех данных указанной сущности</returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Получение записи с указанным id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>Получение записи с указанным id</returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Добавление записи указанной сущности
        /// </summary>
        /// <param name="item">Объект указанной сущности</param>
        /// <returns></returns>
        Task Create(T item);
        /// <summary>
        /// Обновление указанной записи данными новой записи
        /// </summary>
        /// <param name="item">Объект с данными новой сущности</param>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns></returns>
        Task Update(T item, int id);
        /// <summary>
        /// Удаление указанной записи
        /// </summary>
        /// <param name="id">id записи в базе данных</param>
        /// <returns></returns>
        Task Delete(int id);
    }
}
