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
    /// Класс-сервис для управления типами инвентаря
    /// </summary>
    public class InventoryTypeService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public InventoryTypeService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех типов инвентаря
        /// </summary>
        /// <returns>возврат всех типов инвентаря</returns>
        public async Task<IEnumerable<InventoryTypeDTO>> GetInventoryTypes()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryTypeRepository(db);
                var inventoryType = await repo.GetAll();
                return inventoryType.Select(i => i.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение id всех типов инвентаря
        /// </summary>
        /// <returns>id всех типов инвентаря</returns>
        public async Task<IEnumerable<int>> GetInventoryTypesID()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryTypeRepository(db);
                var types= await repo.GetAll();
                var typesID = types.Select(t => t.TypeID);
                return typesID;
            }
        }
        /// <summary>
        /// Получение типа инвентаря по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>тип инвентаря</returns>
        public async Task<InventoryTypeDTO> GetInventoryTypeById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryTypeRepository(db);
                var itemType = await repo.GetById(id);
                return itemType.ToDTO();
            }
        }
    }
}
