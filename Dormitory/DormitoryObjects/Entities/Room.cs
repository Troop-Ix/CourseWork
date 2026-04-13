using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace DormitoryObjects
{
    [Table(Name = "Комнаты")]
    public class Room
    {
        [Column(Name = "КомнатаID"), PrimaryKey, Identity]
        public int RoomID { get; set; }

        [Column(Name = "Номер")]
        public int Number { get; set; }

        [Column(Name = "Этаж")]
        public int Floor { get; set; }

        [Column(Name = "Площадь")] public decimal Area { get; set; }

        [Column(Name = "Вместимость")]
        public int Capacity { get; set; }

        [Association(ThisKey = "RoomID", OtherKey = "RoomID")]
        public List<Student> Students { get; set; }

        [Association(ThisKey = "RoomID", OtherKey = "RoomID")]
        public List<Inventory> Inventory { get; set; }
    }
}
