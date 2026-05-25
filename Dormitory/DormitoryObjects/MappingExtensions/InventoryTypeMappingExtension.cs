using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class InventoryTypeMappingExtension
    {
        /// <summary>
        /// Преобразование сущности типа инвентаря в класс DTO
        /// </summary>
        /// <param name="benefitType">тип инвентаря</param>
        /// <returns>класс DTO типа инвентаря</returns>
        public static InventoryTypeDTO ToDTO(this InventoryType inventoryType)
        {
            if (inventoryType == null) return null;
            return new InventoryTypeDTO()
            {
                TypeID = inventoryType.TypeID,
                Name = inventoryType.Name,
                Inventory = inventoryType.Inventory?.Select(i => i.ToDTO()).ToList() ?? new List<InventoryDTO>()
            };
        }
    }
}
