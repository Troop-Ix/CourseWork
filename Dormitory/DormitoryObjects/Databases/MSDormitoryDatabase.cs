using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Databases
{
    public class MSDormitoryDatabase : DataConnection
    {
        private static MSDormitoryDatabase _instance;
        private readonly static object _lock = new object();
        private MSDormitoryDatabase(string connectionString)
             : base(new DataOptions().UseSqlServer(connectionString))
        {
        }

        public static MSDormitoryDatabase GetInstance(string connectionString = null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    if (string.IsNullOrEmpty(connectionString))
                        throw new ArgumentNullException(nameof(connectionString), "Connection string required for first initialization");

                    _instance = new MSDormitoryDatabase(connectionString);
                }
                return _instance;
            }
        }
        public async Task<bool> TestConnection()
        {
            try
            {
                await this.ExecuteAsync<int>("SELECT 1");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ITable<Room> Rooms => this.GetTable<Room>();
        public ITable<Student> Students => this.GetTable<Student>();
        public ITable<Payment> Payments => this.GetTable<Payment>();
        public ITable<Inventory> Inventory => this.GetTable<Inventory>();
        public ITable<BenefitType> BenefitTypes => this.GetTable<BenefitType>();
        public ITable<StudentBenefit> StudentBenefits => this.GetTable<StudentBenefit>();
        public ITable<User> Users => this.GetTable<User>();
    }
}
