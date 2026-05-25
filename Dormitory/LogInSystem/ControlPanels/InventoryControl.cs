using DormitoryObjects;
using DormitoryObjects.DTO;
using DormitoryObjects.Repositories;
using DormitoryObjects.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInSystem
{
    /// <summary>
    /// Пользовательский элемент управления для отображения таблиц с информацией по инвентарю, типам инвентаря и состояниям инвентаря
    /// </summary>
    public partial class InventoryControl : UserControl
    {
        InventoryService _inventoryService;
        InventoryTypeService _inventoryTypesService;
        InventoryStateService _inventoryStatesService;
        public InventoryControl(InventoryService inventoryService, InventoryTypeService inventoryTypesService, InventoryStateService inventoryStatesService)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.MultiSelect = false;

            _inventoryService = inventoryService;
            _inventoryTypesService = inventoryTypesService;
            _inventoryStatesService = inventoryStatesService;
            this.Load += InventoryControl_Load;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        /// <summary>
        /// Одновременная загрузка всей информации по всем таблицам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void InventoryControl_Load(object sender, EventArgs e)
        {
            try
            {
                await Task.WhenAll(
                LoadDataGrid(() => _inventoryService.GetInventory(), dataGridView1),
                LoadDataGrid(() => _inventoryTypesService.GetInventoryTypes(), dataGridView3),
                LoadDataGrid(() => _inventoryStatesService.GetInventoryStates(), dataGridView2));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные: {ex.Message}",
                                    "Ошибка базы данных",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Загрузка информации по инвентарю
        /// </summary>
        /// <returns></returns>
        public async Task LoadInventory()
        {
            await LoadDataGrid(() => _inventoryService.GetInventory(), dataGridView1);
        }
        /// <summary>
        /// Загрузка данных в выбранную таблицу с помощью заданного метода
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataFunc">Метод для получения данных</param>
        /// <param name="dataGrid">Таблица для заполнения полученными данными</param>
        /// <returns></returns>
        private async Task LoadDataGrid<T>(Func<Task<IEnumerable<T>>> dataFunc, DataGridView dataGrid)
        {
            try
            {
                var data = await dataFunc();
                dataGrid.DataSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Возврат id из выбранной строкм в таблице инвентаря
        /// </summary>
        /// <returns></returns>
        public  int? GetSelectedItemID()
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Cells[0].Value == null)
            {
                return null;
            }
            if (int.TryParse(dataGridView1.CurrentRow.Cells[0].Value.ToString(), out int id))
            {
                return id;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Форматирование ячеек таблицы инвентаря для корректного отображения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var inventory = dataGridView1.Rows[e.RowIndex].DataBoundItem as InventoryDTO;
            if (inventory == null) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "RoomNumber")
            {
                e.Value = inventory.Room != null ? inventory.Room.Number.ToString() : "-";
                e.FormattingApplied = true;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "TypeID")
            {
                e.Value = inventory.InventoryType != null ? inventory.InventoryType.TypeID.ToString() : "-";
                e.FormattingApplied = true;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "StateID")
            {
                e.Value = inventory.InventoryState != null ? inventory.InventoryState.StateID.ToString() : "-";
                e.FormattingApplied = true;
            }
        }

    }
}
