using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    public class RoomDTO
    {
        /// <summary>
        /// ID комнаты
        /// </summary>
        public int RoomID { get; set; }
        /// <summary>
        /// Номер комнаты
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Этаж, на котором расположена комната
        /// </summary>
        public int Floor { get; set; }
        /// <summary>
        /// Площадь комнаты
        /// </summary>
        public decimal Area { get; set; }
        /// <summary>
        /// Вместимость комнаты
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// Список студентов, проживающих в комнате
        /// </summary>
        public List<StudentDTO> Students { get; set; }
        /// <summary>
        /// Список инвентарных вещей, записанных на комнату
        /// </summary>
        public List<InventoryDTO> Inventory { get; set; }
    }
}
