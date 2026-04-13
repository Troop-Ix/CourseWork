using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    [Table(Name = "Пользователи")]
    public class User
    {
        [Column(Name = "ПользовательID"), PrimaryKey, Identity]
        public int UserID { get; set; }

        [Column(Name = "Фамилия")]
        public string Surname { get; set; }

        [Column(Name = "Имя")]
        public string Name { get; set; }

        [Column(Name = "Отчество")]
        public string Middlename { get; set; }

        [Column(Name = "Логин")]
        public string Login { get; set; }

        [Column(Name = "Тип")]
        public string Type { get; set; }
    }
}
