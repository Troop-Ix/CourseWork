using DormitoryObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class BenefitTypeMappingExtension
    {
        /// <summary>
        /// Преобразование сущности типа льгот в класс DTO
        /// </summary>
        /// <param name="benefitType">тип льгот</param>
        /// <returns>класс DTO типа льгот</returns>
        public static BenefitTypeDTO ToDTO(this BenefitType benefitType)
        {
            if (benefitType == null) return null;
            return new BenefitTypeDTO()
            {
                BenefitID = benefitType.BenefitID,
                Name = benefitType.Name,
                Description = benefitType.Description,
                StudentBenefits = benefitType.StudentBenefits?.Select(s => s.ToDTO()).ToList() ?? new List<StudentBenefitDTO>()
            };
        }
    }
}
