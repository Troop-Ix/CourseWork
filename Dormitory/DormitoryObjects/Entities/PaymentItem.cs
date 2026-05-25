using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Entities
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "ПредметыОплат". Представляет предметы оплат
    /// </summary>
    [Table(Name = "ПредметыОплат")]
    public class PaymentItem
    {
        /// <summary>
        /// ID предмета оплаты
        /// </summary>
        [Column(Name = "ПредметОплатыID"), PrimaryKey, Identity]
        public int PaymentItemID { get; set; }
        /// <summary>
        /// Название предмета оплаты
        /// </summary>
        [Column(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Список оплат, которые относятся к данному предмет оплат
        /// </summary>
        [Association(ThisKey = "PaymentItemID", OtherKey = "PaymentItemID")]
        public List<Payment> Payments { get; set; }
    }
}
