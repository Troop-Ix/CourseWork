using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Entities
{
    [Table(Name = "ТипыИнвентаря")]
    public class InventoryTypes
    {
        [Column(Name = "ТипИнвентаряID"), PrimaryKey, Identity]
        public int TypeID { get; set; }
        [Column(Name = "Название")]
        public string Name { get; set; }
        [Association(ThisKey = "TypeID", OtherKey = "TypeID")]
        public List<Inventory> Inventory { get; set; }
    }
}
