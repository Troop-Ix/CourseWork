using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class RoomMappingExtension
    {
        /// <summary>
        /// Преобразование сущности комнаты в класс DTO
        /// </summary>
        /// <param name="benefitType">комната</param>
        /// <returns>класс DTO комнаты</returns>
        public static RoomDTO ToDTO(this Room room)
        {
            if (room == null) return null;
            return new RoomDTO()
            {
                RoomID = room.RoomID,
                Number = room.Number,
                Floor = room.Floor,
                Area = room.Area,
                Capacity = room.Capacity,
                Students = room.Students?.Select(s => s.ToDTO()).ToList() ?? new List<StudentDTO>(),
                Inventory = room.Inventory?.Select(i => i.ToDTO()).ToList() ?? new List<InventoryDTO>()
            };
        }
    }
}
