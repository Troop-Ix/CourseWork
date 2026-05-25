using DormitoryObjects.Entities;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    public class PaymentDTO
    {
        /// <summary>
        /// ID оплаты
        /// </summary>
        public int PaymentID { get; set; }
        /// <summary>
        /// Сумма, внесенная для покрытия оплаты
        /// </summary>
        public decimal PaidAmount { get; set; }
        /// <summary>
        /// Сумма, которую необходимо внести
        /// </summary>
        public decimal AmountDue { get; set; }

        /// <summary>
        /// Дата последний оплаты
        /// </summary>
        /// <value>Дата или null (если сумма для покрытия оплаты ещё не вносилась)</value>
        public DateTime? LastPaymentDate { get; set; }
        /// <summary>
        /// Объект студента, связанный с оплатой
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Объект предмета оплаты, связанный с оплатой
        /// </summary>
        public PaymentItem PaymentItem { get; set; }
    }
}
