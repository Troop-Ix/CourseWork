using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.RepositoriesInterfaces;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей предметы оплат
    /// </summary>
    public class PaymentItemRepository : IPaymentItemRepository
    {
        protected readonly IDormitoryDatabase _db;

        public PaymentItemRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о предметах оплат
        /// </summary>
        /// <returns>Получение всех данных о предметах оплат</returns>
        public async Task<IEnumerable<PaymentItem>> GetAll()
        {
            return await _db.PaymentItems.LoadWith(p=>p.Payments).OrderBy(p => p.PaymentItemID).ToListAsync();
        }
        /// <summary>
        /// Получение данных о предмете оплаты с заданным id
        /// </summary>
        /// <param name="id">id предмета оплаты</param>
        /// <returns>Данные о предмете оплаты с заданным id</returns>
        public async Task<PaymentItem> GetById(int id)
        {
            return await _db.PaymentItems.LoadWith(p => p.Payments).FirstOrDefaultAsync(p => p.PaymentItemID == id);
        }
        /// <summary>
        /// Добавление предмета оплат
        /// </summary>
        /// <param name="paymentItem">Предмет оплат</param>
        /// <returns></returns>
        public async Task Create(PaymentItem paymentItem)
        {
            if (paymentItem != null)
            {
                await _db.InsertAsync(paymentItem);
            }
        }
        /// <summary>
        /// Обновление информации о предмете оплат с указанным id
        /// </summary>
        /// <param name="paymentItem">Объект предмета оплат с новой информацией</param>
        /// <param name="id">id изменяемого предмета оплат</param>
        /// <returns></returns>
        public async Task Update(PaymentItem paymentItem, int id)
        {
            var oldPaymentItem = await _db.PaymentItems.LoadWith(p => p.Payments).FirstOrDefaultAsync(p => p.PaymentItemID == id);
            if (oldPaymentItem != null)
            {
                oldPaymentItem.PaymentItemID=paymentItem.PaymentItemID;
                oldPaymentItem.Name=paymentItem.Name;
                await _db.UpdateAsync(oldPaymentItem);
            }
        }
        /// <summary>
        /// Удаление предмета оплат с заданным id
        /// </summary>
        /// <param name="id">id предмета оплат</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.PaymentItems.Where(p => p.PaymentItemID == id).DeleteAsync();
        }
    }
}
