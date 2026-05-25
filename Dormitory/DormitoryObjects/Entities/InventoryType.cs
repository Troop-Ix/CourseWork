using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Entities
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "ТипыИнвентаря". Представляет типы инвентаря
    /// </summary>
    [Table(Name = "ТипыИнвентаря")]
    public class InventoryType
    {
        /// <summary>
        /// ID типа предмета
        /// </summary>
        [Column(Name = "ТипИнвентаряID"), PrimaryKey, Identity]
        public int TypeID { get; set; }
        /// <summary>
        /// Название типа предмета
        /// </summary>
        [Column(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Список предметов инвентаря, которые имеют данный тип
        /// </summary>
        [Association(ThisKey = "TypeID", OtherKey = "TypeID")]
        public List<Inventory> Inventory { get; set; }
    }
}
