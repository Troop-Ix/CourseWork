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
    public partial class BenefitControl : UserControl
    {
        BenefitTypeService _benefitTypeService;
        public BenefitControl(BenefitTypeService benefitTypeService)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            _benefitTypeService = benefitTypeService;
            this.Load += BenefitType_Load;
        }
        private async void BenefitType_Load(object sender, EventArgs e)
        {
            await LoadBenefitType();
        }
        private async Task LoadBenefitType()
        {
            try
            {
                var benefitTypes = await _benefitTypeService.GetBenefitTypes();
                dataGridView1.DataSource = benefitTypes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить данные: {ex.Message}",
                                "Ошибка базы данных",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
