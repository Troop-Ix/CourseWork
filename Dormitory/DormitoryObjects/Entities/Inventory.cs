using DormitoryObjects;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "Инвентарь". Содержит информацию по предмету и номер комнаты, к которому он привязан
    /// </summary>
    [Table(Name = "Инвентарь")]
    public class Inventory
    {
        /// <summary>
        /// ID предмета
        /// </summary>
        [Column(Name = "ПредметID"), PrimaryKey, Identity]
        public int ItemID { get; set; }
        /// <summary>
        /// ID комнаты, к которой привязан предмет
        /// </summary>
        /// <value>Целое число или null (предмет может быть не привязан к какой-либо комнате)</value>
        [Column(Name = "КомнатаID")]
        public int? RoomID { get; set; }
        /// <summary>
        /// Наименование предмета
        /// </summary>
        [Column(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Состояние предмета
        /// </summary>
        [Column(Name = "Состояние")]
        public string Condition { get; set; }
        /// <summary>
        /// Дата приобретения предмета
        /// </summary>
        [Column(Name = "ДатаПриобретения")]
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Объект комнаты, к которой привязан предмет
        /// </summary>
        [Association(ThisKey = "RoomID", OtherKey = "RoomID", CanBeNull = true)]
        public Room Room { get; set; }
    }
}
