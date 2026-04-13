using DormitoryObjects;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    [Table(Name = "Студенты")]
    public class Student
    {
        [Column(Name = "СтудентID"), PrimaryKey, Identity]
        public int StudentID { get; set; }

        [Column(Name = "КомнатаID")]
        public int? RoomID { get; set; }

        [Column(Name = "Фамилия")]
        public string Surname { get; set; }

        [Column(Name = "Имя")]
        public string Name { get; set; }

        [Column(Name = "Отчество")]
        public string Middlename { get; set; }

        [Column(Name = "ДатаРождения")]
        public DateTime Birthdate { get; set; }

        [Column(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Column(Name = "Факультет")]
        public string Faculty { get; set; }

        [Column(Name = "Группа")]
        public string Group { get; set; }

        [Association(ThisKey = "RoomID", OtherKey = "RoomID", CanBeNull = true)]
        public Room Room { get; set; }

        [Association(ThisKey = "StudentID", OtherKey = "StudentID")]
        public List<StudentBenefit> StudentBenefits { get; set; }

        [Association(ThisKey = "StudentID", OtherKey = "StudentID")]
        public List<Payment> Payments { get; set; }
    }
}
