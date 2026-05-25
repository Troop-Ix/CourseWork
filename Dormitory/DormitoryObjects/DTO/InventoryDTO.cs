using DormitoryObjects.Entities;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    public class InventoryDTO
    {
        /// <summary>
        /// ID предмета
        /// </summary>
        public int ItemID { get; set; }
        /// <summary>
        /// Дата приобретения предмета
        /// </summary>
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// Объект комнаты, к которой привязан предмет
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// Объект типа предмета, которым он является
        /// </summary>
        public InventoryType InventoryType { get; set; }
        /// <summary>
        /// Объект состояния предмета
        /// </summary>
        public InventoryState InventoryState { get; set; }
    }
}
