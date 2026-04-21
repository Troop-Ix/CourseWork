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
    /// Класс, представляющий запись из таблицы "ТипыЛьгот". Содержит информацию по льготам
    /// </summary>
    [Table(Name = "ТипыЛьгот")]
    public class BenefitType
    {
        /// <summary>
        /// ID льготы
        /// </summary>
        [Column(Name = "ЛьготаID"), PrimaryKey, Identity]
        public int BenefitID { get; set; }
        /// <summary>
        /// Наименование льготы
        /// </summary>
        [Column(Name = "Название")]
        public string Name { get; set; }
        /// <summary>
        /// Описание льготы
        /// </summary>
        [Column(Name = "Описание")]
        public string Description { get; set; }
        /// <summary>
        /// Список с информацией по выдаче данной льготы студентам
        /// </summary>
        [Association(ThisKey = "BenefitID", OtherKey = "BenefitID")]
        public List<StudentBenefit> StudentBenefits { get; set; }
    }

}
