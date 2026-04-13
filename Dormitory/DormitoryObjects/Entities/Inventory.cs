using DormitoryObjects;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    [Table(Name = "Инвентарь")]
    public class Inventory
    {
        [Column(Name = "ПредметID"), PrimaryKey, Identity]
        public int ItemID { get; set; }

        [Column(Name = "КомнатаID")]
        public int? RoomID { get; set; }

        [Column(Name = "Название")]
        public string Name { get; set; }

        [Column(Name = "Состояние")]
        public string Condition { get; set; }

        [Column(Name = "ДатаПриобретения")]
        public DateTime PurchaseDate { get; set; }

        [Association(ThisKey = "RoomID", OtherKey = "RoomID", CanBeNull = true)]
        public Room Room { get; set; }
    }
}
