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
        public async Task<bool> AddPayment(int studentID, decimal paidAmount, decimal amountDue, string paymentItem, DateTime? lastPaymentDate)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new PaymentRepository(db);
                    var payment = new Payment { StudentID = studentID, PaidAmount = paidAmount, AmountDue = amountDue, PaymentItem = paymentItem, LastPaymentDate = lastPaymentDate };
                    await repo.Create(payment);
                    return true;
                }
                catch (Exception ex)
                { return false; }
            }
        }

        public async Task<bool> ChangePayment(int paymentId, decimal amount, DateTime date)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new PaymentRepository(db);
                    var payment = await repo.GetById(paymentId);
                    if (payment == null)
                    {
                        return false;
                    }
                    payment.PaidAmount = amount;
                    payment.LastPaymentDate = date;
                    await repo.Update(payment, paymentId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public async Task<bool> RemovePayment(int paymentId)
        {
            using (var db = _factory.Create())
            {
                try
                {
                    var repo = new PaymentRepository(db);
                    await repo.Delete(paymentId);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
