using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    /// <summary>
    /// Класс, представляющий связь между студентами и льготами (таблица "ЛьготыСтудентов").
    /// Реализует отношение "многие ко многим"
    /// </summary>
    [Table(Name = "ЛьготыСтудентов")]
    public class StudentBenefit
    {
        /// <summary>
        /// ID записи в таблице
        /// </summary>
        [Column(Name = "ЛьготаСтудента"), PrimaryKey, Identity]
        public int StudentBenefitID { get; set; }
        /// <summary>
        /// ID студента
        /// </summary>
        [Column(Name = "СтудентID")]
        public int StudentID { get; set; }
        /// <summary>
        /// ID льготы
        /// </summary>
        [Column(Name = "ЛьготаID")]
        public int BenefitID { get; set; }
        /// <summary>
        /// Дата выдачи льготы студенту
        /// </summary>
        [Column(Name = "ДатаВыдачи")]
        public DateTime IssueDate { get; set; }
        /// <summary>
        /// Объект студента, у которого имеется указанная льгота
        /// </summary>
        [Association(ThisKey = "StudentID", OtherKey = "StudentID", CanBeNull = false)]
        public Student Student { get; set; }
        /// <summary>
        /// Объект льготы, имеющаяся у указанного студента
        /// </summary>
        [Association(ThisKey = "BenefitID", OtherKey = "BenefitID", CanBeNull = false)]
        public BenefitType BenefitType { get; set; }
    }
}
