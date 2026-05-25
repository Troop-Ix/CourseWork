using DormitoryObjects.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MappingExtensions
{
    public static class StudentMappingExtension
    {
        /// <summary>
        /// Преобразование сущности студента в класс DTO
        /// </summary>
        /// <param name="benefitType">студент</param>
        /// <returns>класс DTO студент</returns>
        public static StudentDTO ToDTO(this Student student)
        {
            if (student == null) return null;
            return new StudentDTO()
            {
                StudentID = student.StudentID,
                Surname = student.Surname,
                Name = student.Name,
                Middlename = student.Middlename,
                Birthdate = student.Birthdate,
                PhoneNumber = student.PhoneNumber,
                Faculty = student.Faculty,
                Group = student.Group,
                Room = student.RoomID != null ? student.Room : null,
                StudentBenefits = student.StudentBenefits?.Select(s=>s.ToDTO()).ToList() ?? new List<StudentBenefitDTO>(),
                Payments = student.Payments?.Select(s=>s.ToDTO()).ToList() ?? new List<PaymentDTO>()
            };
        }
    }
}
