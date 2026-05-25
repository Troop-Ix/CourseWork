using DormitoryObjects.DTO;
using DormitoryObjects.Entities;
using DormitoryObjects.Fabrics;
using DormitoryObjects.MappingExtensions;
using DormitoryObjects.MSRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Класс-сервис для управления состояниями инвентаря
    /// </summary>
    public class InventoryStateService
    {
        private readonly IDbFactory _dbFactory;
        private readonly IRepositoryFactory _repoFactory;
        public InventoryStateService(IDbFactory dbFactory, IRepositoryFactory repoFactory)
        {
            _dbFactory = dbFactory;
            _repoFactory = repoFactory;
        }
        /// <summary>
        /// Получение всех состояний инвентаря
        /// </summary>
        /// <returns>возврат всех состояний инвентаря</returns>
        public async Task<IEnumerable<InventoryStateDTO>> GetInventoryStates()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryStateRepository(db);
                var inventoryStates = await repo.GetAll();
                return inventoryStates.Select(i => i.ToDTO()).ToList();
            }
        }
        /// <summary>
        /// Получение id всех состояний инвентаря
        /// </summary>
        /// <returns>id всех состояний инвентаря</returns>
        public async Task<IEnumerable<int>> GetInventoryStatesID()
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryStateRepository(db);
                var states = await repo.GetAll();
                var statesID = states.Select(s => s.StateID);
                return statesID;
            }
        }
        /// <summary>
        /// Получение состояния инвентаря по id
        /// </summary>
        /// <param name="id">id записи в источнике данных</param>
        /// <returns>состояние инвентаря</returns>
        public async Task<InventoryStateDTO> GetInventoryStateById(int id)
        {
            using (var db = _dbFactory.Create())
            {
                var repo = _repoFactory.CreateInventoryStateRepository(db);
                var itemState = await repo.GetById(id);
                return itemState.ToDTO();
            }
        }
    }
}
