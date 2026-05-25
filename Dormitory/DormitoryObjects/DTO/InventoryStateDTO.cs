using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "СостоянияИнвентаря". Представляет состояние инвентаря
    /// </summary>
    public class InventoryStateDTO
    {
        /// <summary>
        /// ID состояния предмета
        /// </summary>
        public int StateID { get; set; }
        /// <summary>
        /// Название состояния предмета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список предметов инвентаря, которые имеют данное состояние
        /// </summary>
        public List<InventoryDTO> Inventory { get; set; }
    }
}
