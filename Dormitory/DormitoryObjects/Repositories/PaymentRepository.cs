using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей оплаты
    /// </summary>
    public class PaymentRepository : IPaymentRepository
    {
        protected readonly IDormitoryDatabase _db;

        public PaymentRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных об оплатах
        /// </summary>
        /// <returns>Получение всех данных об оплатах</returns>
        public async Task<IEnumerable<Payment>> GetAll()
        {
            var payments = await _db.Payments.LoadWith(p => p.PaymentItem).LoadWith(p => p.Student).OrderBy(p => p.PaymentID).ToListAsync();
            return payments;
        }
        /// <summary>
        /// Получение данных об оплате с заданным id
        /// </summary>
        /// <param name="id">id оплаты</param>
        /// <returns>Данные об оплате с заданным id</returns>
        public async Task<Payment> GetById(int id)
        {
            return await _db.Payments.LoadWith(p => p.PaymentItem).LoadWith(p => p.Student).FirstOrDefaultAsync(p => p.PaymentID == id);
        }
        /// <summary>
        /// Добавление оплаты
        /// </summary>
        /// <param name="payment">Оплата</param>
        /// <returns></returns>
        public async Task Create(Payment payment)
        {
            if (payment != null)
            {
                await _db.InsertAsync(payment);
            }
        }
        /// <summary>
        /// Обновление информации об оплате с указанным id
        /// </summary>
        /// <param name="payment">Объект оплаты с новой информацией</param>
        /// <param name="id">id изменяемой оплаты</param>
        /// <returns></returns>
        public async Task Update(Payment payment, int id)
        {
            var oldPayment = await _db.Payments.LoadWith(p => p.PaymentItem).LoadWith(p => p.Student).FirstOrDefaultAsync(p => p.PaymentID == id);
            if (oldPayment != null)
            {
                oldPayment.StudentID = payment.StudentID;
                oldPayment.AmountDue = payment.AmountDue;
                oldPayment.PaidAmount = payment.PaidAmount;
                oldPayment.PaymentItemID = payment.PaymentItemID;
                oldPayment.LastPaymentDate = payment.LastPaymentDate;
                await _db.UpdateAsync(oldPayment);
            }
        }
        /// <summary>
        /// Удаление оплаты с заданным id
        /// </summary>
        /// <param name="id">id оплаты</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.Payments.Where(p => p.PaymentID == id).DeleteAsync();
        }
    }
}
