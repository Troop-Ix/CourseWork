using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    [Table(Name = "ЛьготыСтудентов")]
    public class StudentBenefit
    {
        [Column(Name = "ЛьготаСтудента"), PrimaryKey, Identity]
        public int StudentBenefitID { get; set; }

        [Column(Name = "СтудентID")]
        public int StudentID { get; set; }

        [Column(Name = "ЛьготаID")]
        public int BenefitID { get; set; }

        [Column(Name = "ДатаВыдачи")]
        public DateTime? IssueDate { get; set; }

        [Association(ThisKey = "StudentID", OtherKey = "StudentID", CanBeNull = false)]
        public Student Student { get; set; }

        [Association(ThisKey = "BenefitID", OtherKey = "BenefitID", CanBeNull = false)]
        public BenefitType BenefitType { get; set; }
    }
}
