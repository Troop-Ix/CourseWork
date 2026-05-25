using DormitoryObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class PaymentMappingExtension
    {
        /// <summary>
        /// Преобразование сущности оплаты в класс DTO
        /// </summary>
        /// <param name="benefitType">оплата</param>
        /// <returns>класс DTO оплаты</returns>
        public static PaymentDTO ToDTO(this Payment payment)
        {
            if (payment == null) return null;
            return new PaymentDTO()
            {
                PaymentID = payment.PaymentID,
                PaidAmount = payment.PaidAmount,
                AmountDue = payment.AmountDue,
                LastPaymentDate = payment.LastPaymentDate,
                Student = payment.Student,
                PaymentItem = payment.PaymentItem
            };
        }
    }
}
