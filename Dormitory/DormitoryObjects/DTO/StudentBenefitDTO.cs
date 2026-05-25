using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    public class StudentBenefitDTO
    {
        /// <summary>
        /// ID записи в таблице
        /// </summary>
        public int StudentBenefitID { get; set; }
        /// <summary>
        /// Дата выдачи льготы студенту
        /// </summary>
        public DateTime IssueDate { get; set; }
        /// <summary>
        /// Объект студента, у которого имеется указанная льгота
        /// </summary>
        public Student Student { get; set; }
        /// <summary>
        /// Объект льготы, имеющаяся у указанного студента
        /// </summary>
        public BenefitType BenefitType { get; set; }
    }
}
