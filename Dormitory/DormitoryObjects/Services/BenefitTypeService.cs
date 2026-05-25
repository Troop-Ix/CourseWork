using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using DormitoryObjects.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Services
{
    /// <summary>
    /// Класс-сервис для управления типами льгот
    /// </summary>
    public class BenefitTypeService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public BenefitTypeService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех типов льгот
        /// </summary>
        /// <returns>возврат всех типов льгот</returns>
        public async Task<IEnumerable<BenefitTypeDTO>> GetBenefitTypes()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateBenefitTypeRepository(db);
                var benefitTypes = await repo.GetAll();
                return benefitTypes.Select(b => b.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение id всех льгот
        /// </summary>
        /// <returns>id всех льгот</returns>
        public async Task<IEnumerable<int>> GetBenefitsID()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateBenefitTypeRepository(db);
                var types = await repo.GetAll();
                var typesID = types.Select(t => t.BenefitID);
                return typesID;
            }
        }
        /// <summary>
        /// Получение типа льготы по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>тип льготы</returns>
        public async Task<BenefitTypeDTO> GetBenefitTypeById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateBenefitTypeRepository(db);
                var benefitType = await repo.GetById(id);
                return benefitType.ToDTO(); 
            }
        }
    }
}
