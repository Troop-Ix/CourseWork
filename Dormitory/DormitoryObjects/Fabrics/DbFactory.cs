using DormitoryObjects.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Fabrics
{
    public class DbFactory : IDbFactory
    {
        private readonly string _connectionString;
        private readonly DatabaseType _type;
        public DbFactory(string connectionString, DatabaseType type)
        {
            _connectionString = connectionString;
            _type = type;
        }
        public IDormitoryDatabase Create()
        {
            switch (_type)
            {
                case DatabaseType.MSDormitoryDatabase:
                    return new MSDormitoryDatabase(_connectionString);
                default:
                    throw new ArgumentException($"Неизвестный тип БД: {_type}");
            }
        }
    }
}
