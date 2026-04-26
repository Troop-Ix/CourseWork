using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public class PaymentItemRepository : IRepository<PaymentItem>
    {
        protected readonly IDormitoryDatabase _db;

        public PaymentItemRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        public async Task<IEnumerable<PaymentItem>> GetAll()
        {
            return await _db.PaymentItems.OrderBy(p => p.PaymentItemID).ToListAsync();
        }

        public async Task<PaymentItem> GetById(int id)
        {
            return await _db.PaymentItems.FirstOrDefaultAsync(p => p.PaymentItemID == id);
        }

        public async Task Create(PaymentItem paymentItem)
        {
            if (paymentItem != null)
            {
                await _db.InsertAsync(paymentItem);
            }
        }

        public async Task Update(PaymentItem paymentItem, int id)
        {
            var oldPaymentItem = await GetById(id);
            if (oldPaymentItem != null)
            {
                oldPaymentItem.PaymentItemID=paymentItem.PaymentItemID;
                oldPaymentItem.Name=paymentItem.Name;
                await _db.UpdateAsync(oldPaymentItem);
            }
        }

        public async Task Delete(int id)
        {
            await _db.PaymentItems.Where(p => p.PaymentItemID == id).DeleteAsync();
        }
    }
}
