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
    public class MSPaymentRepository : IRepository<Payment>
    {
        protected readonly MSDormitoryDatabase _db;

        public MSPaymentRepository(MSDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Payment>> GetAll()
        {
            var payments = await _db.Payments.ToListAsync();
            return payments;
        }

        public async Task<Payment> GetById(int id)
        {
            var payment = await _db.Payments.FirstOrDefaultAsync(p => p.PaymentID == id);
            return payment;
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
            if (payment != null)
            {
                payment.PaymentID = id;
                await _db.UpdateAsync(payment);
            }
        }

        public async Task Delete(int id)
        {
            await _db.Payments.Where(p => p.PaymentID == id).DeleteAsync();
        }
    }
}
