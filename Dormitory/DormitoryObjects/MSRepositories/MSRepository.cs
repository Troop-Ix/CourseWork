using DormitoryObjects.Repositories;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    public class MSRepository : IGeneralRepository
    {
        protected readonly DataOptions options;
        public MSRepository(string connectionString)
        {
            options = new DataOptions().UseSqlServer(connectionString);
        }
        public static bool TestConnection(string connectionString)
        {
            var testOptions = new DataOptions().UseSqlServer(connectionString);
            try
            {
                using (var db = new DataConnection(testOptions))
                {
                    db.Execute<int>("SELECT 1");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Room>> FilterRoomByOccupancy(int roomsCount)
        {
            using (var db = new DataConnection(options))
            {
                var rooms = await db.GetTable<Room>().LoadWith(r => r.Students).Where(r => r.Students.Count == roomsCount).ToListAsync();
                return rooms;
            }
        }

        public async Task<IEnumerable<BenefitType>> GetBenefitTypes()
        {
            using (var db = new DataConnection(options))
            {
                var benefitTypes = await db.GetTable<BenefitType>().ToListAsync();
                return benefitTypes;
            }
        }

        public async Task<IEnumerable<Room>> GetEmptyRooms()
        {
            using (var db = new DataConnection(options))
            {
                var rooms = await db.GetTable<Room>().LoadWith(r => r.Students).Where(r => r.Students.Count == 0).ToListAsync();
                return rooms;
            }
        }

        public async Task<IEnumerable<Room>> GetFullRooms()
        {
            using (var db = new DataConnection(options))
            {
                var rooms = await db.GetTable<Room>().LoadWith(r => r.Students).Where(r => r.Students.Count == r.Capacity).ToListAsync();
                return rooms;
            }
        }

        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            using (var db = new DataConnection(options))
            {
                var items = await db.GetTable<Inventory>().ToListAsync();
                return items;
            }
        }

        public async Task<IEnumerable<Room>> GetPartlyOccupiedRooms()
        {
            using (var db = new DataConnection(options))
            {
                var rooms = await db.GetTable<Room>().LoadWith(r => r.Students).Where(r => r.Students.Count > 0 && r.Students.Count < r.Capacity).ToListAsync();
                return rooms;
            }
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            using (var db = new DataConnection(options))
            {
                var payments = await db.GetTable<Payment>().ToListAsync();
                return payments;
            }
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            using (var db = new DataConnection(options))
            {
                var rooms = await db.GetTable<Room>().ToListAsync();
                return rooms;
            }
        }

        public async Task<IEnumerable<StudentBenefit>> GetStudentBenefits()
        {
            using (var db = new DataConnection(options))
            {
                var students = await db.GetTable<StudentBenefit>().ToListAsync();
                return students;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            using (var db = new DataConnection(options))
            {
                var students = await db.GetTable<Student>().LoadWith(s => s.StudentBenefits).ToListAsync();
                return students;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsBySurname(string surname)
        {
            using (var db = new DataConnection(options))
            {
                var students = await db.GetTable<Student>().Where(s => s.Surname.Contains(surname)).ToListAsync();
                return students;
            }
        }
        public User GetUser(string login)
        {
            using (var db = new DataConnection(options))
            {
                var user = db.GetTable<User>().SingleOrDefault(u => u.Login == login);
                return user;
            }
        }
    }
}
