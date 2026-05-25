using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Fabrics
{
    /// <summary>
    /// Интерфейс для создания репозиториев
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Создать репозиторий инвентаря
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий инвентаря</returns>
        IInventoryRepository CreateInventoryRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий типов инвентаря
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий типов инвентаря</returns>
        IInventoryTypeRepository CreateInventoryTypeRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий состояний инвентаря
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий состояний инвентаря</returns>
        IInventoryStateRepository CreateInventoryStateRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий комнат
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий комнат</returns>
        IRoomAdvancedRepository CreateRoomRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий видов льгот
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий видов льгот</returns>
        IBenefitTypeRepository CreateBenefitTypeRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий предметов оплат
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий предметов оплат</returns>
        IPaymentItemRepository CreatePaymentItemRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий оплат
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий оплат</returns>
        IPaymentRepository CreatePaymentRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий студентов
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий студентов</returns>
        IStudentAdvancedRepository CreateStudentAdvancedRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий пользователей
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий пользователей</returns>
        IUserAdvancedRepository CreateUserAdvancedRepository(IDormitoryDatabase db);
        /// <summary>
        /// Создать репозиторий льгот студентов
        /// </summary>
        /// <param name="db">контекст базы данных</param>
        /// <returns>репозиторий льгот студентов</returns>
        IStudentBenefitRepository CreateStudentBenefitRepository(IDormitoryDatabase db);
    }
}
