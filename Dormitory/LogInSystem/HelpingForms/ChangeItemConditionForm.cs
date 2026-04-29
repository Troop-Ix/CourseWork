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
using static System.Windows.Forms.AxHost;

namespace LogInSystem.HelpingForms
{
    public partial class ChangeItemConditionForm : Form
    {
        InventoryService _inventoryService;
        InventoryStatesService _inventoryStatesService;
        int itemID;
        public ChangeItemConditionForm(int itemID, InventoryService inventoryService, InventoryStatesService inventoryStatesService)
        {
            InitializeComponent();
            this.itemID = itemID;
            _inventoryService = inventoryService;
            _inventoryStatesService = inventoryStatesService;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        private async void LoadInitialization()
        {
            var states = await _inventoryStatesService.GetInventoryStates();
            StatesList.DataSource = states.ToList();
            StatesList.DisplayMember = "Name";
            StatesList.ValueMember = "StateID";
            if (states.Any())
            {
                Change.Enabled = true;
                StatesList.SelectedIndex = 0;
            }
            else
            {
                Change.Enabled = false;
            }
        }
        private async void Change_Click(object sender, EventArgs e)
        {
            int state = (int)StatesList.SelectedValue;
            try
            {
                await _inventoryService.UpdateInventoryCondition(itemID, state);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось изменить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
