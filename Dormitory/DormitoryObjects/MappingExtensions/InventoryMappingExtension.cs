using DormitoryObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class InventoryMappingExtension
    {
        /// <summary>
        /// Преобразование сущности инвентаря в класс DTO
        /// </summary>
        /// <param name="benefitType">инвентарь</param>
        /// <returns>класс DTO инвентаря</returns>
        public static InventoryDTO ToDTO(this Inventory inventory)
        {
            if (inventory == null) return null;
            return new InventoryDTO()
            {
                ItemID = inventory.ItemID,
                PurchaseDate = inventory.PurchaseDate,
                Room = inventory.RoomID != null ? inventory.Room : null,
                InventoryType = inventory.InventoryType,
                InventoryState = inventory.InventoryState
            };
        }
    }
}
