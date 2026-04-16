using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class CommandantService : GeneralService
    {
        public CommandantService(IRoomAdvancedRepository roomRepo, IStudentAdvancedRepository studentRepo,
                             IUserAdvancedRepository userRepo, IRepository<Inventory> inventoryRepo,
                             IRepository<StudentBenefit> studentBenefitRepo, IRepository<BenefitType> benefitTypeRepo, IRepository<Payment> paymentRepo)
                            : base(roomRepo, studentRepo, userRepo, inventoryRepo,
                             studentBenefitRepo, benefitTypeRepo, paymentRepo)
        { }

        public async Task<bool> EvictStudent(int studentId)
        {
            var student = await _studentRepo.GetById(studentId);
            if (student == null)
                return false;
            student.RoomID = null;
            await _studentRepo.Update(student, studentId);
            return true;
        }
        public async Task<bool> SetRoomForStudent(int studentId, int roomId)
        {
            var room = await _roomRepo.GetById(roomId);
            if (room == null || room.Students.Count >= room.Capacity) { return false; }
            var student = await _studentRepo.GetById(studentId);

            if (student == null)
                return false;
            student.RoomID = roomId;
            await _studentRepo.Update(student, studentId);
            return true;
        }
        public async Task<bool> AddPayment(Payment payment)
        {
            try
            {
                await _paymentRepo.Create(payment);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public async Task<bool> ChangePayment(int paymentId, decimal amount, DateTime date)
        {
            try
            {
                var payment = await _paymentRepo.GetById(paymentId);
                if (payment == null)
                {
                    return false;
                }
                payment.PaidAmount = amount;
                payment.LastPaymentDate = date;
                await _paymentRepo.Update(payment, paymentId);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public async Task<bool> RemovePayment(int paymentId)
        {
            try
            {
                await _paymentRepo.Delete(paymentId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> SetInventoryForRoom(int itemId, int roomId)
        {
            try
            {
                var room = await _roomRepo.GetById(roomId);
                if (room == null)
                    return false;
                var inventory = await _inventoryRepo.GetById(itemId);

                if (inventory == null)
                    return false;
                inventory.RoomID = roomId;
                await _inventoryRepo.Update(inventory, itemId);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public async Task<bool> RemoveInventoryFromRoom(int itemId)
        {
            try
            {
                var inventory = await _inventoryRepo.GetById(itemId);

                if (inventory == null)
                    return false;

                inventory.RoomID = null;
                await _inventoryRepo.Update(inventory, itemId);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public async Task<bool> SetBenefitForStudent(StudentBenefit studentBenefit)
        {
            try
            {
                var studentExists = studentBenefit.Student;
                if (studentExists == null) return false;

                var benefitExists = studentBenefit.BenefitType;
                if (benefitExists == null) return false;

                await _studentBenefitRepo.Create(studentBenefit);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> RemoveBenefitFromStudent(int benefitId)
        {
            try
            {
                await _studentBenefitRepo.Delete(benefitId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
