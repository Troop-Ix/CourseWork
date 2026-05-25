using DormitoryObjects.Databases;
using DormitoryObjects.Entities;
using DormitoryObjects.RepositoriesInterfaces;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.Repositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей состояния инвентаря
    /// </summary>
    public class InventoryStateRepository: IInventoryStateRepository
    {
        protected readonly IDormitoryDatabase _db;

        public InventoryStateRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о состояниях инвентаря
        /// </summary>
        /// <returns>Получение всех данных состояниях инвентаря</returns>
        public async Task<IEnumerable<InventoryState>> GetAll()
        {
            return await _db.InventoryStates.LoadWith(i => i.Inventory).OrderBy(i => i.StateID).ToListAsync();
        }
        /// <summary>
        /// Получение данных о состояние инвентаря с заданным id
        /// </summary>
        /// <param name="id">id состояниях инвентаря</param>
        /// <returns>Данные о состояние инвентаря с заданным id</returns>
        public async Task<InventoryState> GetById(int id)
        {
            return await _db.InventoryStates.LoadWith(i => i.Inventory).FirstOrDefaultAsync(i => i.StateID == id);
        }
        /// <summary>
        /// Добавление состояния инвентаря
        /// </summary>
        /// <param name="itemState">Состояние инвентаря</param>
        /// <returns></returns>
        public async Task Create(InventoryState itemState)
        {
            if (itemState != null)
            {
                await _db.InsertAsync(itemState);
            }
        }
        /// <summary>
        /// Обновление информации о состояние инвентаря с указанным id
        /// </summary>
        /// <param name="itemState">Объект состояниея инвентаря с новой информацией</param>
        /// <param name="id">id изменяемого состояния инвентаря</param>
        /// <returns></returns>
        public async Task Update(InventoryState itemState, int id)
        {
            var oldItemState = await _db.InventoryStates.LoadWith(i => i.Inventory).FirstOrDefaultAsync(i => i.StateID == id);
            if (oldItemState != null)
            {
                oldItemState.Name = itemState.Name;
                await _db.UpdateAsync(oldItemState);
            }
        }
        /// <summary>
        /// Удаление состояния инвентаря с заданным id
        /// </summary>
        /// <param name="id">id состояния инвентаря</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.InventoryStates.Where(i => i.StateID == id).DeleteAsync();
        }
    }
}
