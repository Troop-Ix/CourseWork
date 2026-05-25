using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class PaymentItemMappingExtension
    {
        /// <summary>
        /// Преобразование сущности предмета оплат в класс DTO
        /// </summary>
        /// <param name="benefitType">предмет оплат</param>
        /// <returns>класс DTO предмет оплат</returns>
        public static PaymentItemDTO ToDTO(this PaymentItem paymentItem)
        {
            if (paymentItem == null) return null;
            return new PaymentItemDTO()
            {
                PaymentItemID = paymentItem.PaymentItemID,
                Name = paymentItem.Name,
                Payments = paymentItem.Payments?.Select(p => p.ToDTO()).ToList() ?? new List<PaymentDTO>()
            };
        }
    }
}
