using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    public interface ICommandantRepository : IGeneralRepository
    {
        Task<bool> EvictStudent(int studentId);
        Task<bool> SetRoomForStudent(int studentId, int roomId);

        Task<bool> SetBenefitForStudent(StudentBenefit studentBenefit);
        Task<bool> RemoveBenefitFromStudent(int benefitId);

        Task<bool> SetInventoryForRoom(int itemId, int roomId);
        Task<bool> RemoveInventoryFromRoom(int itemId);

        Task<bool> AddPayment(Payment payment);
        Task<bool> RemovePayment(int paymentId);
        Task<bool> ChangePayment(int paymentId, decimal amount, DateTime date);

    }
}
