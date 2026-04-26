using DormitoryObjects.Entities;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Databases
{
    public class MSDormitoryDatabase : DataConnection, IDormitoryDatabase
    {
        public MSDormitoryDatabase(string connectionString) : base(new DataOptions().UseSqlServer(connectionString)) 
        {}

        public ITable<Room> Rooms => this.GetTable<Room>();
        public ITable<Student> Students => this.GetTable<Student>();
        public ITable<Payment> Payments => this.GetTable<Payment>();
        public ITable<PaymentItem> PaymentItems => this.GetTable<PaymentItem>();
        public ITable<Inventory> Inventory => this.GetTable<Inventory>();
        public ITable<InventoryStates> InventoryStates => this.GetTable<InventoryStates>();
        public ITable<InventoryTypes> InventoryTypes => this.GetTable<InventoryTypes>();
        public ITable<BenefitType> BenefitTypes => this.GetTable<BenefitType>();
        public ITable<StudentBenefit> StudentBenefits => this.GetTable<StudentBenefit>();
        public ITable<User> Users => this.GetTable<User>();

        Task<int> IDormitoryDatabase.InsertAsync<T>(T entity) => this.InsertAsync(entity);
        Task<int> IDormitoryDatabase.UpdateAsync<T>(T entity) => this.UpdateAsync(entity);
        Task<int> IDormitoryDatabase.DeleteAsync<T>(T entity) => this.DeleteAsync(entity);
    }
}
