using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class GeneralService
    {
        protected readonly IRoomAdvancedRepository _roomRepo;
        protected readonly IStudentAdvancedRepository _studentRepo;
        protected readonly IUserAdvancedRepository _userRepo;
        protected readonly IRepository<Inventory> _inventoryRepo;
        protected readonly IRepository<StudentBenefit> _studentBenefitRepo;
        protected readonly IRepository<BenefitType> _benefitTypeRepo;
        protected readonly IRepository<Payment> _paymentRepo;

        public GeneralService(IRoomAdvancedRepository roomRepo, IStudentAdvancedRepository studentRepo,
                             IUserAdvancedRepository userRepo, IRepository<Inventory> inventoryRepo,
                             IRepository<StudentBenefit> studentBenefitRepo, IRepository<BenefitType> benefitTypeRepo, IRepository<Payment> paymentRepo)
        {
            _roomRepo = roomRepo;
            _studentRepo = studentRepo;
            _userRepo = userRepo;
            _inventoryRepo = inventoryRepo;
            _studentBenefitRepo = studentBenefitRepo;
            _benefitTypeRepo = benefitTypeRepo;
            _paymentRepo = paymentRepo;
        }
        public async Task<IEnumerable<Student>> GetStudents(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
            {
                return await _studentRepo.GetAll();
            }

            return await _studentRepo.GetStudentsBySurname(surname);
        }
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _paymentRepo.GetAll();
        }
        public async Task<IEnumerable<Inventory>> GetInventory()
        {
            return await _inventoryRepo.GetAll();
        }
        public async Task<IEnumerable<StudentBenefit>> GetStudentBenefits()
        {
            return await _studentBenefitRepo.GetAll();
        }
        public async Task<IEnumerable<BenefitType>> GetBenefitTypes()
        {
            return await _benefitTypeRepo.GetAll();
        }
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _roomRepo.GetAll();
        }
        public async Task<User> GetUserByLogin(string login)
        {
            return await _userRepo.GetByLogin(login);
        }
        public async Task<IEnumerable<Room>> GetFilteredRooms(int roomsCount)
        {
            return await _roomRepo.FilterRoomByOccupancy(roomsCount);
        }
        public async Task<IEnumerable<Room>> GetEmptyRooms()
        {
            return await _roomRepo.GetEmptyRooms();
        }
        public async Task<IEnumerable<Room>> GetFullRooms()
        {
            return await _roomRepo.GetFullRooms();
        }
        public async Task<IEnumerable<Room>> GetPartlyOccupiedRooms()
        {
            return await _roomRepo.GetPartlyOccupiedRooms();
        }
    }
}
