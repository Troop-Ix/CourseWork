using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    [Table(Name = "Оплаты")]
    public class Payment
    {
        [Column(Name = "ОплатаID"), PrimaryKey, Identity]
        public int PaymentID { get; set; }

        [Column(Name = "СтудентID")]
        public int StudentID { get; set; }

        [Column(Name = "Внесено")]
        public decimal PaidAmount { get; set; }

        [Column(Name = "СуммаКОплате")]
        public decimal AmountDue { get; set; }

        [Column(Name = "ПредметОплаты")]
        public string PaymentItem { get; set; }

        [Column(Name = "ДатаПоследнейОплаты")]
        public DateTime? LastPaymentDate { get; set; }

        [Association(ThisKey = "StudentID", OtherKey = "StudentID", CanBeNull = false)]
        public Student Student { get; set; }
    }
}
