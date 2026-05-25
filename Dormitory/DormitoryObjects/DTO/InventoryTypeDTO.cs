using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "ТипыИнвентаря". Представляет типы инвентаря
    /// </summary>
    public class InventoryTypeDTO
    {
        /// <summary>
        /// ID типа предмета
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// Название типа предмета
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список предметов инвентаря, которые имеют данный тип
        /// </summary>
        public List<InventoryDTO> Inventory { get; set; }
    }
}
