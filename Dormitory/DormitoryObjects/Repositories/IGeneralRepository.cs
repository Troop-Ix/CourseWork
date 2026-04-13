using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public interface IGeneralRepository
    {
        User GetUser(string login);
        Task<IEnumerable<Room>> GetRooms();
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Payment>> GetPayments();
        Task<IEnumerable<Inventory>> GetInventory();
        Task<IEnumerable<StudentBenefit>> GetStudentBenefits();
        Task<IEnumerable<BenefitType>> GetBenefitTypes();

        Task<IEnumerable<Room>> GetPartlyOccupiedRooms();
        Task<IEnumerable<Room>> GetFullRooms();
        Task<IEnumerable<Room>> GetEmptyRooms();

        Task<IEnumerable<Student>> GetStudentsBySurname(string surname);
        Task<IEnumerable<Room>> FilterRoomByOccupancy(int roomCount);
    }
}
