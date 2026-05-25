using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    public class StudentDTO
    {
        /// <summary>
        /// ID студента
        /// </summary>
        public int StudentID { get; set; }
        /// <summary>
        /// Фамилия студента
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя студента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Отчество студента
        /// </summary>
        public string Middlename { get; set; }
        /// <summary>
        /// День рождения студента
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// Номер телефона студента
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Факультет, на котором обучается студент
        /// </summary>
        public string Faculty { get; set; }
        /// <summary>
        /// Группа, в которой обучается студент
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Объект комнаты, в которой проживает студент
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// Список льгот, связанных со студентом
        /// </summary>
        public List<StudentBenefitDTO> StudentBenefits { get; set; }
        /// <summary>
        /// Список оплат, связанных со студентом
        /// </summary>
        public List<PaymentDTO> Payments { get; set; }
    }
}
