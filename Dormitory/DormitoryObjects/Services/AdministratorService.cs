using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    public class AdministratorService : GeneralService
    {
        public AdministratorService(IRoomAdvancedRepository roomRepo, IStudentAdvancedRepository studentRepo,
                     IUserAdvancedRepository userRepo, IRepository<Inventory> inventoryRepo,
                     IRepository<StudentBenefit> studentBenefitRepo, IRepository<BenefitType> benefitTypeRepo, IRepository<Payment> paymentRepo)
                    : base(roomRepo, studentRepo, userRepo, inventoryRepo,
                     studentBenefitRepo, benefitTypeRepo, paymentRepo)
        { }

        public async Task<bool> AddInventory(Inventory item)
        {
            try
            {
                await _inventoryRepo.Create(item);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateInventoryCondition(int itemId, string condition)
        {
            try
            {
                var item = await _inventoryRepo.GetById(itemId);
                if (item == null)
                    return false;
                item.Condition = condition;
                await _inventoryRepo.Update(item, itemId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> RemoveInventory(int itemId)
        {
            try
            {
                await _inventoryRepo.Delete(itemId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<IEnumerable<Student>> GetDebtors()
        {
            return await _studentRepo.GetDebtors();
        }
    }
}
