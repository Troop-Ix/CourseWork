using DormitoryObjects.Databases;
using DormitoryObjects.Repositories;
using DormitoryObjects.RepositoriesInterfaces;
using LinqToDB;
using LinqToDB.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormitoryObjects.MSRepositories
{
    /// <summary>
    /// Паттерн "Репозиторий", реализующий CRUD-операции с таблицей инвентарь
    /// </summary>
    public class InventoryRepository : IInventoryRepository
    {
        protected readonly IDormitoryDatabase _db;

        public InventoryRepository(IDormitoryDatabase db)
        {
            _db = db;
        }
        /// <summary>
        /// Получение всех данных об инвентаре
        /// </summary>
        /// <returns>Получение всех данных об инвентаре</returns>
        public async Task<IEnumerable<Inventory>> GetAll()
        {
            return await _db.Inventory.LoadWith(i => i.InventoryState).LoadWith(i => i.InventoryType).LoadWith(i => i.Room).OrderBy(i => i.ItemID).ToListAsync();
        }
        /// <summary>
        /// Получение данных о предмете с заданным id
        /// </summary>
        /// <param name="id">id предмета</param>
        /// <returns>Данные о предмете с заданным id</returns>
        public async Task<Inventory> GetById(int id)
        {
            return await _db.Inventory.LoadWith(i=>i.InventoryState).LoadWith(i=>i.InventoryType).LoadWith(i => i.Room).FirstOrDefaultAsync(i => i.ItemID == id);
        }
        /// <summary>
        /// Добавление предмета
        /// </summary>
        /// <param name="item">Предмет</param>
        /// <returns></returns>
        public async Task Create(Inventory item)
        {
            if (item != null)
            {
                await _db.InsertAsync(item);
            }
        }
        /// <summary>
        /// Обновление информации о предмете с указанным id
        /// </summary>
        /// <param name="item">Объект предмета с новой информацией</param>
        /// <param name="id">id изменяемого предмета</param>
        /// <returns></returns>
        public async Task Update(Inventory item, int id)
        {
            var oldItem = await _db.Inventory.LoadWith(i => i.InventoryState).LoadWith(i => i.InventoryType).LoadWith(i => i.Room).FirstOrDefaultAsync(i => i.ItemID == id);
            if (oldItem != null)
            {
                oldItem.TypeID = item.TypeID;
                oldItem.StateID = item.StateID;
                oldItem.RoomID = item.RoomID;
                oldItem.PurchaseDate = item.PurchaseDate;
                await _db.UpdateAsync(oldItem);
            }
        }
        /// <summary>
        /// Удаление предмета с заданным id
        /// </summary>
        /// <param name="id">id предмета</param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            await _db.Inventory.Where(i => i.ItemID == id).DeleteAsync();
        }
    }
}
