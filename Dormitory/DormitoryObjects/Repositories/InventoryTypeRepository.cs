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
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей типы инвентаря
    /// </summary>
    public class InventoryTypeRepository: IInventoryTypeRepository
    {
        protected readonly IDormitoryDatabase _db;

        public InventoryTypeRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных о типах инвентаря
        /// </summary>
        /// <returns>Получение всех данных о типах инвентаря</returns>
        public async Task<IEnumerable<InventoryType>> GetAll()
        {
            return await _db.InventoryTypes.LoadWith(i => i.Inventory).OrderBy(i => i.TypeID).ToListAsync();
        }
        /// <summary>
        /// Получение данных о типе инвентаря с заданным id
        /// </summary>
        /// <param name="id">id типа инвентаря</param>
        /// <returns>Данные о типе инвентаря с заданным id</returns>
        public async Task<InventoryType> GetById(int id)
        {
            return await _db.InventoryTypes.LoadWith(i => i.Inventory).FirstOrDefaultAsync(i => i.TypeID == id);
        }
        /// <summary>
        /// Добавление типа инвентаря
        /// </summary>
        /// <param name="itemType">Тип инвентаря</param>
        /// <returns></returns>
        public async Task Create(InventoryType itemType)
        {
            if (itemType != null)
            {
                await _db.InsertAsync(itemType);
            }
        }
        /// <summary>
        /// Обновление информации о типе инвентаря с указанным id
        /// </summary>
        /// <param name="itemType">Объект типа инвентаря с новой информацией</param>
        /// <param name="id">id изменяемого типа инвентаря</param>
        /// <returns></returns>
        public async Task Update(InventoryType itemType, int id)
        {
            var oldItemType = await _db.InventoryTypes.LoadWith(i => i.Inventory).FirstOrDefaultAsync(i => i.TypeID == id);
            if (oldItemType != null)
            {
               oldItemType.Name = itemType.Name;
               await _db.UpdateAsync(oldItemType);
            }
        }
        /// <summary>
        /// Удаление типа инвентаря с заданным id
        /// </summary>
        /// <param name="id">id типа инвентаря</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.InventoryTypes.Where(i => i.TypeID == id).DeleteAsync();
        }
    }
}
