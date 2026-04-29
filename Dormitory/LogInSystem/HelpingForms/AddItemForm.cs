using DormitoryObjects.Entities;
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

namespace LogInSystem.HelpingForms
{
    public partial class AddItemForm : Form
    {
        InventoryService _inventoryService;
        InventoryTypesService _inventoryTypesService;
        public AddItemForm(InventoryService inventoryService, InventoryTypesService inventoryTypesService)
        {
            InitializeComponent();
            _inventoryService = inventoryService;
            _inventoryTypesService = inventoryTypesService;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        private async void LoadInitialization()
        {
            var types = await _inventoryTypesService.GetInventoryTypes();
            TypesList.DataSource = types.ToList();
            TypesList.DisplayMember = "Name";
            TypesList.ValueMember = "TypeID";
            if (types.Any())
            {
                Add.Enabled = true;
                TypesList.SelectedIndex = 0;
            }
            else
            {
                Add.Enabled = false;
            }
        }
        private async void Add_Click(object sender, EventArgs e)
        {
            DateTime dateOfPurchase = DateOfPurchase.Value;
            int state = 1;
            int type = (int)TypesList.SelectedValue;

            try
            {
                await _inventoryService.AddInventory(state, type, dateOfPurchase);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
