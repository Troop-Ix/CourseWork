using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Entities
{
    [Table(Name = "СостоянияИнвентаря")]
    public class InventoryStates
    {
        [Column(Name = "СостояниеID"), PrimaryKey, Identity]
        public int StateID { get; set; }
        [Column(Name = "Название")]
        public string Name { get; set; }
        [Association(ThisKey = "StateID", OtherKey = "StateID")]
        public List<Inventory> Inventory { get; set; }
    }
}
