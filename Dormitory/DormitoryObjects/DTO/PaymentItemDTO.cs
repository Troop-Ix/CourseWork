using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "ПредметыОплат". Представляет предметы оплат
    /// </summary>
    public class PaymentItemDTO
    {
        /// <summary>
        /// ID предмета оплаты
        /// </summary>
        public int PaymentItemID { get; set; }
        /// <summary>
        /// Название предмета оплаты
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список оплат, которые относятся к данному предмет оплат
        /// </summary>
        public List<PaymentDTO> Payments { get; set; }
    }
}
