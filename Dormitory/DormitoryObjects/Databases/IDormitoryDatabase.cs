using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Databases
{
    /// <summary>
    /// Интерфейс, представляющий шаблон базы данных Dormitory
    /// </summary>
    public interface IDormitoryDatabase: IDisposable
    {
        /// <summary>
        /// Свойство для работа с таблицей "Комнаты"
        /// </summary>
        ITable<Room> Rooms { get; }
        /// <summary>
        /// Свойство для работа с таблицей "Студенты"
        /// </summary>
        ITable<Student> Students { get; }
        /// <summary>
        /// Свойство для работа с таблицей "Оплаты"
        /// </summary>
        ITable<Payment> Payments { get; }
        /// <summary>
        /// Свойство для работа с таблицей "Инвентарь"
        /// </summary>
        ITable<Inventory> Inventory { get; }
        /// <summary>
        /// Свойство для работа с таблицей "ТипыЛьгот"
        /// </summary>
        ITable<BenefitType> BenefitTypes { get; }
        /// <summary>
        /// Свойство для работа с таблицей "ЛьготыСтудентов"
        /// </summary>
        ITable<StudentBenefit> StudentBenefits { get; }
        /// <summary>
        /// Свойство для работа с таблицей "Пользователи"
        /// </summary>
        ITable<User> Users { get; }
        /// <summary>
        /// Свойство для работа с таблицей "Комнаты"
        /// </summary>
        Task<int> InsertAsync<T>(T entity);
        Task<int> UpdateAsync<T>(T entity);
        Task<int> DeleteAsync<T>(T entity);
    }
}
