using DormitoryObjects.Entities;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DormitoryObjects.Databases
{
    /// <summary>
    /// Интерфейс, представляющий шаблон базы данных Dormitory
    /// </summary>
    public interface IDormitoryDatabase: IDisposable
    {
        /// <summary>
        /// Свойство для работа с сущностью "Комнаты"
        /// </summary>
        ITable<Room> Rooms { get; }
        /// <summary>
        /// Свойство для работа с сущностью "Студенты"
        /// </summary>
        ITable<Student> Students { get; }
        /// <summary>
        /// Свойство для работа с сущностью "Оплаты"
        /// </summary>
        ITable<Payment> Payments { get; }
        /// <summary>
        /// Свойство для работы с сущностью "Предметы оплаты"
        /// </summary>
        ITable<PaymentItem> PaymentItems { get; }
        /// <summary>
        /// Свойство для работа с сущностью "Инвентарь"
        /// </summary>
        ITable<Inventory> Inventory { get; }
        /// <summary>
        /// Свойство для работы с сущностью "СостояниеИнвентаря"
        /// </summary>
        ITable<InventoryState> InventoryStates { get; }
        /// <summary>
        /// Свойство для работы с сущностью "ТипыИнвентаря"
        /// </summary>
        ITable<InventoryType> InventoryTypes { get; }
        /// <summary>
        /// Свойство для работа с сущностью "ТипыЛьгот"
        /// </summary>
        ITable<BenefitType> BenefitTypes { get; }
        /// <summary>
        /// Свойство для работа с сущностью "ЛьготыСтудентов"
        /// </summary>
        ITable<StudentBenefit> StudentBenefits { get; }
        /// <summary>
        /// Свойство для работа с сущностью "Пользователи"
        /// </summary>
        ITable<User> Users { get; }
        /// <summary>
        /// Асинхронная вставка записи в таблицу
        /// </summary>
        /// <typeparam name="T">Вид сущности, указывающий таблицу</typeparam>
        /// <param name="entity">Новая запись</param>
        /// <returns></returns>
        Task<int> InsertAsync<T>(T entity);
        /// <summary>
        /// Асинхронное обновление записи в таблице
        /// </summary>
        /// <typeparam name="T">Вид сущности, указывающий таблицу</typeparam>
        /// <param name="entity">Обновленная запись</param>
        /// <returns></returns>
        Task<int> UpdateAsync<T>(T entity);
        /// <summary>
        /// Асинхронное удаление записи из таблицы
        /// </summary>
        /// <typeparam name="T">Вид сущности, указывающий таблицу</typeparam>
        /// <param name="entity">Удаляемая запись</param>
        /// <returns></returns>
        Task<int> DeleteAsync<T>(T entity);
    }
}
