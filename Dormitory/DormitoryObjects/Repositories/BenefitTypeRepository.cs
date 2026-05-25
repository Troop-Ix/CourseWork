using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Async;
using System.Text;
using System.Threading.Tasks;
using DormitoryObjects.RepositoriesInterfaces;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей типы льгот
    /// </summary>
    public class BenefitTypeRepository : IBenefitTypeRepository
    {
        private readonly IDormitoryDatabase _db;

        public BenefitTypeRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о типах льгот
        /// </summary>
        /// <returns>Получение всех данных о типах льгот</returns>
        public async Task<IEnumerable<BenefitType>> GetAll()
        {
            var benefitTypes = await _db.BenefitTypes.LoadWith(b => b.StudentBenefits).OrderBy(b => b.BenefitID).ToListAsync();
            return benefitTypes;
        }
        /// <summary>
        /// Получение данных о типе льгот с заданным id
        /// </summary>
        /// <param name="id">id типа льгот</param>
        /// <returns>Данные о типе льгот с заданным id</returns>
        public async Task<BenefitType> GetById(int id)
        {
            var benefitType = await _db.BenefitTypes.LoadWith(b => b.StudentBenefits).FirstOrDefaultAsync(bt => bt.BenefitID == id);
            return benefitType;
        }
        /// <summary>
        /// Добавление типа льгот
        /// </summary>
        /// <param name="benefitType">Тип льгот</param>
        /// <returns></returns>
        public async Task Create(BenefitType benefitType)
        {
            if (benefitType != null)
            {
                await _db.InsertAsync(benefitType);
            }
        }
        /// <summary>
        /// Обновление информации о типе льгот с указанным id
        /// </summary>
        /// <param name="benefitType">Объект типа льгот с новой информацией</param>
        /// <param name="id">id изменяемого типа льгот</param>
        /// <returns></returns>
        public async Task Update(BenefitType benefitType, int id)
        {
            var oldBenefitType = await _db.BenefitTypes.LoadWith(b => b.StudentBenefits).FirstOrDefaultAsync(bt => bt.BenefitID == id);
            if (oldBenefitType != null)
            {
                oldBenefitType.Name = benefitType.Name;
                oldBenefitType.Description = benefitType.Description;
                await _db.UpdateAsync(oldBenefitType);
            }
        }
        /// <summary>
        /// Удаление типа льгот с заданным id
        /// </summary>
        /// <param name="id">id типа льгот</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.BenefitTypes.Where(bt => bt.BenefitID == id).DeleteAsync();
        }
    }
}
