using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MSRepositories;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class PaymentItemService
    {
        private readonly IDbFactory _factory;
        public PaymentItemService(IDbFactory factory)
        {
            _factory = factory;
        }
        public async Task<IEnumerable<PaymentItem>> GetPaymentItems()
        {
            using (var db = _factory.Create())
            {
                var repo = new PaymentItemRepository(db);
                return await repo.GetAll();
            }
        }
        public async Task<IEnumerable<int>> GetPaymentItemsID()
        {
            using (var db = _factory.Create())
            {
                var repo = new PaymentItemRepository(db);
                var items = await repo.GetAll();
                var itemsID = items.Select(i => i.PaymentItemID);
                return itemsID;
            }
        }
    }
}
