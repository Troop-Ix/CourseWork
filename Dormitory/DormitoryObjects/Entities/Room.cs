using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace DormitoryObjects
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "Комнаты". Содержит номер, этаж, площадь и вместимость комнаты.
    /// </summary>
    [Table(Name = "Комнаты")]
    public class Room
    {
        /// <summary>
        /// ID комнаты
        /// </summary>
        [Column(Name = "КомнатаID"), PrimaryKey, Identity]
        public int RoomID { get; set; }
        /// <summary>
        /// Номер комнаты
        /// </summary>
        [Column(Name = "Номер")]
        public int Number { get; set; }
        /// <summary>
        /// Этаж, на котором расположена комната
        /// </summary>
        [Column(Name = "Этаж")]
        public int Floor { get; set; }
        /// <summary>
        /// Площадь комнаты
        /// </summary>
        [Column(Name = "Площадь")] 
        public decimal Area { get; set; }
        /// <summary>
        /// Вместимость комнаты
        /// </summary>
        [Column(Name = "Вместимость")]
        public int Capacity { get; set; }
        /// <summary>
        /// Список студентов, проживающих в комнате
        /// </summary>
        [Association(ThisKey = "RoomID", OtherKey = "RoomID")]
        public List<Student> Students { get; set; }
        /// <summary>
        /// Список инвентарных вещей, записанных на комнату
        /// </summary>
        [Association(ThisKey = "RoomID", OtherKey = "RoomID")]
        public List<Inventory> Inventory { get; set; }
    }
}
