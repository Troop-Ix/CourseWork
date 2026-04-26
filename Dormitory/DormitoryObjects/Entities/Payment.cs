using DormitoryObjects.Entities;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "Оплаты". Содержит информацию по оплате и студента, к которому она привязана.
    /// </summary>
    [Table(Name = "Оплаты")]
    public class Payment
    {
        /// <summary>
        /// ID оплаты
        /// </summary>
        [Column(Name = "ОплатаID"), PrimaryKey, Identity]
        public int PaymentID { get; set; }
        /// <summary>
        /// ID студента, связанный с оплатой
        /// </summary>
        [Column(Name = "СтудентID")]
        public int StudentID { get; set; }
        /// <summary>
        /// ID предмета оплаты, описывающий предоставляемые услуги
        /// </summary>
        [Column(Name = "ПредметОплатыID")]
        public int PaymentItemID { get; set; }
        /// <summary>
        /// Сумма, внесенная для покрытия оплаты
        /// </summary>
        [Column(Name = "Внесено")]
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// Сумма, которую необходимо внести
        /// </summary>
        [Column(Name = "СуммаКОплате")]
        public decimal AmountDue { get; set; }

        /// <summary>
        /// Дата последний оплаты
        /// </summary>
        /// <value>Дата или null (если сумма для покрытия оплаты ещё не вносилась)</value>
        [Column(Name = "ДатаПоследнейОплаты")]
        public DateTime? LastPaymentDate { get; set; }
        /// <summary>
        /// Объект студента, связанный с оплатой
        /// </summary>
        [Association(ThisKey = "StudentID", OtherKey = "StudentID", CanBeNull = false)]
        public Student Student { get; set; }
        [Association(ThisKey = "PaymentItemID", OtherKey = "PaymentItemID", CanBeNull = false)]
        public PaymentItem PaymentItem { get; set; }
    }
}
