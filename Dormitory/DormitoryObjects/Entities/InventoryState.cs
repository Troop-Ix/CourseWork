using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Entities
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "СостоянияИнвентаря". Представляет состояние инвентаря
    /// </summary>
    [Table(Name = "СостоянияИнвентаря")]
    public class InventoryState
    {
        /// <summary>
        /// ID состояния предмета
        /// </summary>
        [Column(Name = "СостояниеID"), PrimaryKey, Identity]
        public int StateID { get; set; }
        /// <summary>
        /// Название состояния предмета
        /// </summary>
        [Column(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Список предметов инвентаря, которые имеют данное состояние
        /// </summary>
        [Association(ThisKey = "StateID", OtherKey = "StateID")]
        public List<Inventory> Inventory { get; set; }
    }
}
