using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class PaymentRepository : IRepository<Payment>
    {
        protected readonly IDormitoryDatabase _db;

        public PaymentRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Payment>> GetAll()
        {
            var payments = await _db.Payments.LoadWith(p => p.PaymentItem).OrderBy(p => p.PaymentID).ToListAsync();
            return payments;
        }

        public async Task<Payment> GetById(int id)
        {
            return await _db.Payments.LoadWith(p => p.PaymentItem).FirstOrDefaultAsync(p => p.PaymentID == id);
        }

        public async Task Create(Payment payment)
        {
            if (payment != null)
            {
                await _db.InsertAsync(payment);
            }
        }

        public async Task Update(Payment payment, int id)
        {
            var oldPayment = await GetById(id);
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

        public async Task Delete(int id)
        {
            await _db.Payments.Where(p => p.PaymentID == id).DeleteAsync();
        }
    }
}
