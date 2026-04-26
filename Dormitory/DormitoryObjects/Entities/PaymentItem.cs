using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Entities
{
    [Table(Name = "ПредметыОплат")]
    public class PaymentItem
    {
        [Column(Name = "ПредметОплатыID"), PrimaryKey, Identity]
        public int PaymentItemID { get; set; }
        [Column(Name = "Название")]
        public string Name { get; set; }
    }
}
