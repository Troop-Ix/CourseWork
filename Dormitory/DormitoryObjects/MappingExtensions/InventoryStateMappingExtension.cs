using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class InventoryStateMappingExtension
    {
        /// <summary>
        /// Преобразование сущности состояния инвентаря в класс DTO
        /// </summary>
        /// <param name="benefitType">состояние инвентаря</param>
        /// <returns>класс DTO состояние инвентаря</returns>
        public static InventoryStateDTO ToDTO(this InventoryState inventoryStates)
        {
            if (inventoryStates == null) return null;
            return new InventoryStateDTO()
            {
                StateID = inventoryStates.StateID,
                Name = inventoryStates.Name,
                Inventory= inventoryStates.Inventory?.Select(i => i.ToDTO()).ToList() ?? new List<InventoryDTO>()
            };
        }
    }
}
