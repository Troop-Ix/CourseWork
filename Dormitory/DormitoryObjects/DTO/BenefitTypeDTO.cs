using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.DTO
{
    public class BenefitTypeDTO
    {
        /// <summary>
        /// ID льготы
        /// </summary>
        public int BenefitID { get; set; }
        /// <summary>
        /// Наименование льготы
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание льготы
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Список с информацией по выдаче данной льготы студентам
        /// </summary>
        public List<StudentBenefitDTO> StudentBenefits { get; set; }
    }
}
