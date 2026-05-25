using DormitoryObjects.DTO;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления оплатами
    /// </summary>
    public class PaymentService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public PaymentService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех оплат
        /// </summary>
        /// <returns>возврат всех оплат</returns>
        public async Task<IEnumerable<PaymentDTO>> GetPayments()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreatePaymentRepository(db);
                var payments = await repo.GetAll();
                await Task.Delay(5000);
                return payments.Select(p => p.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Добавление оплаты
        /// </summary>
        /// <param name="studentID">id студента, которому назначается оплата</param>
        /// <param name="paidAmount">Внесённая сумма</param>
        /// <param name="amountDue">Необходимая для внесения сумма</param>
        /// <param name="paymentItemID">id предмета оплаты</param>
        /// <param name="lastPaymentDate">Дата последней оплаты</param>
        /// <returns></returns>
        public async Task AddPayment(int studentID, decimal paidAmount, decimal amountDue, int paymentItemID, DateTime? lastPaymentDate)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreatePaymentRepository(db);
                    var payment = new Payment { StudentID = studentID, PaidAmount = paidAmount, AmountDue = amountDue, PaymentItemID = paymentItemID, LastPaymentDate = lastPaymentDate };
                    await repo.Create(payment);
            }
        }
        /// <summary>
        /// Изменение оплаты
        /// </summary>
        /// <param name="paymentId">id оплаты, которая изменяется</param>
        /// <param name="amount">Новая внесённая сумма</param>
        /// <param name="date">Дата последней оплаты</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ChangePayment(int paymentId, decimal amount, DateTime date)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreatePaymentRepository(db);
                    var payment = await repo.GetById(paymentId) ?? throw new Exception("Платеж не найден в базе данных"); 

                    payment.PaidAmount = amount;
                    payment.LastPaymentDate = date;
                    await repo.Update(payment, paymentId);
            }
        }
        /// <summary>
        /// Удаление оплаты
        /// </summary>
        /// <param name="paymentId">id удаляемой оплаты</param>
        /// <returns></returns>
        public async Task RemovePayment(int paymentId)
        {
            using (var db = _dbFactory.Create())
            {
                    var repo = _repoFactory.CreatePaymentRepository(db);
                    await repo.Delete(paymentId);
            }
        }
        /// <summary>
        /// Получение оплаты по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>оплата</returns>
        public async Task<PaymentDTO> GetPaymentByID(int id)
        {
            using ( var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreatePaymentRepository(db);
                var payment = await repo.GetById(id);
                return payment.ToDTO();
            }
        }
    }
}
