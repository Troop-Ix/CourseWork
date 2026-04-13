using DormitoryObjects;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    [Table(Name = "ТипыЛьгот")]
    public class BenefitType
    {
        [Column(Name = "ЛьготаID"), PrimaryKey, Identity]
        public int BenefitID { get; set; }

        [Column(Name = "Название")]
        public string Name { get; set; }

        [Column(Name = "Описание")]
        public string Description { get; set; }

        [Association(ThisKey = "BenefitID", OtherKey = "BenefitID")]
        public List<StudentBenefit> StudentBenefits { get; set; }
    }

}
