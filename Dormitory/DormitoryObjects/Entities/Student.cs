using DormitoryObjects;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "Студенты", содержащая личную информацию, факультет, группу, комнату и оплаты студента
    /// </summary>
    [Table(Name = "Студенты")]
    public class Student
    {
        /// <summary>
        /// ID студента
        /// </summary>
        [Column(Name = "СтудентID"), PrimaryKey, Identity]
        public int StudentID { get; set; }
        /// <summary>
        /// ID комнаты, в которой проживает студент.
        /// </summary>
        /// <value>Целое число или null (если студент не заселён)</value>
        [Column(Name = "КомнатаID")]
        public int? RoomID { get; set; }
        /// <summary>
        /// Фамилия студента
        /// </summary>
        [Column(Name = "Фамилия")]
        public string Surname { get; set; }
        /// <summary>
        /// Имя студента
        /// </summary>
        [Column(Name = "Имя")]
        public string Name { get; set; }
        /// <summary>
        /// Отчество студента
        /// </summary>
        [Column(Name = "Отчество")]
        public string Middlename { get; set; }
        /// <summary>
        /// День рождения студента
        /// </summary>
        [Column(Name = "ДатаРождения")]
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// Номер телефона студента
        /// </summary>
        [Column(Name = "Телефон")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Факультет, на котором обучается студент
        /// </summary>
        [Column(Name = "Факультет")]
        public string Faculty { get; set; }
        /// <summary>
        /// Группа, в которой обучается студент
        /// </summary>
        [Column(Name = "Группа")]
        public string Group { get; set; }
        /// <summary>
        /// Объект комнаты, в которой проживает студент
        /// </summary>
        [Association(ThisKey = "RoomID", OtherKey = "RoomID", CanBeNull = true)]
        public Room Room { get; set; }
        /// <summary>
        /// Список льгот, связанных со студентом
        /// </summary>
        [Association(ThisKey = "StudentID", OtherKey = "StudentID")]
        public List<StudentBenefit> StudentBenefits { get; set; }
        /// <summary>
        /// Список оплат, связанных со студентом
        /// </summary>
        [Association(ThisKey = "StudentID", OtherKey = "StudentID")]
        public List<Payment> Payments { get; set; }
    }
}
