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
    public partial class InventoryControl : UserControl
    {
        InventoryService _inventoryService;
        InventoryTypesService _inventoryTypesService;
        InventoryStatesService _inventoryStatesService;
        public InventoryControl(InventoryService inventoryService, InventoryTypesService inventoryTypesService, InventoryStatesService inventoryStatesService)
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
        }
        private async void InventoryControl_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(
            LoadDataGrid(() => _inventoryService.GetInventory(), dataGridView1),
            LoadDataGrid(() => _inventoryTypesService.GetInventoryTypes(), dataGridView3),
            LoadDataGrid(() => _inventoryStatesService.GetInventoryStates(), dataGridView2));
        }
        public async Task LoadInventory()
        {
            await LoadDataGrid(() => _inventoryService.GetInventory(), dataGridView1);
        }
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
        public async Task<bool> RemoveItemFromRoom()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    int id = (int)row.Cells[0].Value;
                    await _inventoryService.RemoveInventoryFromRoom(id);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
