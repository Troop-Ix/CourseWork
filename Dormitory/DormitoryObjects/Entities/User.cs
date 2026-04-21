using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects
{
    /// <summary>
    /// Класс, представляющий запись из таблицы "Пользователи". Содержит информацию по пользователям системы, их логин и тип доступа
    /// </summary>
    [Table(Name = "Пользователи")]
    public class User
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        [Column(Name = "ПользовательID"), PrimaryKey, Identity]
        public int UserID { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        [Column(Name = "Фамилия")]
        public string Surname { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Column(Name = "Имя")]
        public string Name { get; set; }
        /// <summary>
        /// Отчество пользователя
        /// </summary>
        [Column(Name = "Отчество")]
        public string Middlename { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Column(Name = "Логин")]
        public string Login { get; set; }
        /// <summary>
        /// Тип доступа к базе данных
        /// </summary>
        [Column(Name = "Тип")]
        public string Type { get; set; }
    }
}
