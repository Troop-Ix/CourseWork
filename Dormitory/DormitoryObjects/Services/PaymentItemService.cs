using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления предметами оплат
    /// </summary>
    public class PaymentItemService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public PaymentItemService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех предметов оплат
        /// </summary>
        /// <returns>возврат всех предметов оплат</returns>
        public async Task<IEnumerable<PaymentItemDTO>> GetPaymentItems()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreatePaymentItemRepository(db);
                var paymentItem = await repo.GetAll();
                return paymentItem.Select(p => p.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение id всех предметов оплат
        /// </summary>
        /// <returns>id всех предметов оплат</returns>
        public async Task<IEnumerable<int>> GetPaymentItemsID()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreatePaymentItemRepository(db);
                var items = await repo.GetAll();
                var itemsID = items.Select(i => i.PaymentItemID);
                return itemsID;
            }
        }
        /// <summary>
        /// Получение предмета оплаты по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>прдемет оплаты</returns>
        public async Task<PaymentItemDTO> GetPaymentItemById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreatePaymentItemRepository(db);
                var paymentItem = await repo.GetById(id);
                return paymentItem.ToDTO();
            }
        }
    }
}
