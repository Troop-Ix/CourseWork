using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class PaymentService
    {
        private readonly IDbFactory _factory;
        public PaymentService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            using (var db = _factory.Create())
            {
                var repo = new PaymentRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task AddPayment(int studentID, decimal paidAmount, decimal amountDue, int paymentItemID, DateTime? lastPaymentDate)
        {
            using (var db = _factory.Create())
            {
                    var repo = new PaymentRepository(db);
                    var payment = new Payment { StudentID = studentID, PaidAmount = paidAmount, AmountDue = amountDue, PaymentItemID = paymentItemID, LastPaymentDate = lastPaymentDate };
                    await repo.Create(payment);
            }
        }

        public async Task ChangePayment(int paymentId, decimal amount, DateTime date)
        {
            using (var db = _factory.Create())
            {
                    var repo = new PaymentRepository(db);
                    var payment = await repo.GetById(paymentId) ?? throw new Exception("Платеж не найден в базе данных"); 

                    payment.PaidAmount = amount;
                    payment.LastPaymentDate = date;
                    await repo.Update(payment, paymentId);
            }
        }
        public async Task RemovePayment(int paymentId)
        {
            using (var db = _factory.Create())
            {
                    var repo = new PaymentRepository(db);
                    await repo.Delete(paymentId);
            }
        }
        public async Task<Payment> GetPaymentByID(int id)
        {
            using ( var db = _factory.Create())
            {
                var repo = new PaymentRepository(db);
                return await repo.GetById(id);
            }
        }
    }
}
