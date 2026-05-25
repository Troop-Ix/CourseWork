using DormitoryObjects.Databases;
using DormitoryObjects.MSRepositories;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Fabrics
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IBenefitTypeRepository CreateBenefitTypeRepository(IDormitoryDatabase db)
        {
            return new BenefitTypeRepository(db);
        }

        public IInventoryRepository CreateInventoryRepository(IDormitoryDatabase db)
        {
            return new InventoryRepository(db);
        }

        public IInventoryStateRepository CreateInventoryStateRepository(IDormitoryDatabase db)
        {
            return new InventoryStateRepository(db);
        }

        public IInventoryTypeRepository CreateInventoryTypeRepository(IDormitoryDatabase db)
        {
            return new InventoryTypeRepository(db);
        }

        public IPaymentItemRepository CreatePaymentItemRepository(IDormitoryDatabase db)
        {
            return new PaymentItemRepository(db);
        }

        public IPaymentRepository CreatePaymentRepository(IDormitoryDatabase db)
        {
            return new PaymentRepository(db);
        }

        public IRoomAdvancedRepository CreateRoomRepository(IDormitoryDatabase db)
        {
            return new RoomAdvancedRepository(db);
        }

        public IStudentAdvancedRepository CreateStudentAdvancedRepository(IDormitoryDatabase db)
        {
            return new StudentAdvancedRepository(db);
        }

        public IUserAdvancedRepository CreateUserAdvancedRepository(IDormitoryDatabase db)
        {
            return new UserAdvancedRepository(db);
        }
        public IStudentBenefitRepository CreateStudentBenefitRepository(IDormitoryDatabase db)
        {
            return new StudentBenefitRepository (db);
        }
    }
}
