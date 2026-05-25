using DormitoryObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class StudentBenefitMappingExtension
    {
        /// <summary>
        /// Преобразование сущности льготы студента в класс DTO
        /// </summary>
        /// <param name="benefitType">льгота студента</param>
        /// <returns>класс DTO льготы студента</returns>
        public static StudentBenefitDTO ToDTO(this StudentBenefit studentBenefit)
        {
            if (studentBenefit == null) return null;
            return new StudentBenefitDTO()
            {
                StudentBenefitID = studentBenefit.StudentBenefitID,
                Student = studentBenefit.Student,
                IssueDate = studentBenefit.IssueDate,
                BenefitType = studentBenefit.BenefitType
            };
        }
    }
}
