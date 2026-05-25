using DormitoryObjects.Entities;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Databases
{
    /// <summary>
    /// Класс MS SQl базы данных
    /// </summary>
    public class MSDormitoryDatabase : DataConnection, IDormitoryDatabase
    {
        public MSDormitoryDatabase(string connectionString) : base(new DataOptions().UseSqlServer(connectionString)) 
        {}
        /// <summary>
        /// Свойство для работа с таблицей "Комнаты"
        /// </summary>
        public ITable<Room> Rooms => this.GetTable<Room>();
        /// <summary>
        /// Свойство для работа с таблицей "Студенты"
        /// </summary>       
        public ITable<Student> Students => this.GetTable<Student>();
        /// <summary>
        /// Свойство для работа с таблицей "Оплаты"
        /// </summary>
        public ITable<Payment> Payments => this.GetTable<Payment>();
        /// <summary>
        /// Свойство для работы с таблицей "Предметы оплаты"
        /// </summary>
        public ITable<PaymentItem> PaymentItems => this.GetTable<PaymentItem>();
        /// <summary>
        /// Свойство для работа с таблицей "Инвентарь"
        /// </summary>
        public ITable<Inventory> Inventory => this.GetTable<Inventory>();
        /// <summary>
        /// Свойство для работы с таблицей "СостояниеИнвентаря"
        /// </summary>
        public ITable<InventoryState> InventoryStates => this.GetTable<InventoryState>();
        /// <summary>
        /// Свойство для работы с таблицей "ТипыИнвентаря"
        /// </summary>
        public ITable<InventoryType> InventoryTypes => this.GetTable<InventoryType>();
        /// <summary>
        /// Свойство для работа с таблицей "ТипыЛьгот"
        /// </summary>
        public ITable<BenefitType> BenefitTypes => this.GetTable<BenefitType>();
        /// <summary>
        /// Свойство для работа с таблицей "ЛьготыСтудентов"
        /// </summary>
        public ITable<StudentBenefit> StudentBenefits => this.GetTable<StudentBenefit>();
        /// <summary>
        /// Свойство для работа с таблицей "Пользователи"
        /// </summary>
        public ITable<User> Users => this.GetTable<User>();
        /// <summary>
        /// Асинхронная вставка записи в таблицу
        /// </summary>
        /// <typeparam name="T">Вид сущности, указывающий таблицу</typeparam>
        /// <param name="entity">Новая запись</param>
        /// <returns></returns>
        Task<int> IDormitoryDatabase.InsertAsync<T>(T entity) => this.InsertAsync(entity);
        /// <summary>
        /// Асинхронное обновление записи в таблице
        /// </summary>
        /// <typeparam name="T">Вид сущности, указывающий таблицу</typeparam>
        /// <param name="entity">Обновленная запись</param>
        /// <returns></returns>
        Task<int> IDormitoryDatabase.UpdateAsync<T>(T entity) => this.UpdateAsync(entity);
        /// <summary>
        /// Асинхронное удаление записи из таблицы
        /// </summary>
        /// <typeparam name="T">Вид сущности, указывающий таблицу</typeparam>
        /// <param name="entity">Удаляемая запись</param>
        /// <returns></returns>
        Task<int> IDormitoryDatabase.DeleteAsync<T>(T entity) => this.DeleteAsync(entity);
    }
}
