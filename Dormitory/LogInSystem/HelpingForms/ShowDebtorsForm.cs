using DormitoryObjects;
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
    public partial class ShowDebtorsForm : Form
    {
        StudentsService _studentsService;
        public ShowDebtorsForm(StudentsService studentsService)
        {
            InitializeComponent();
            _studentsService = studentsService;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            this.Load += StudentsControl_Load;
        }
        private async void StudentsControl_Load(object sender, EventArgs e)
        {
            await LoadStudents();
        }
        public async Task LoadStudents()
        {
            try
            {
                var debtors = await _studentsService.GetDebtors();
                var displayList = debtors.Select(d => new
                {
                    d.Surname,
                    d.Name,
                    d.Middlename,
                    PaidAmount=d.Payments.Sum(p=>p.PaidAmount),
                    AmountDue=d.Payments.Sum(p=>p.AmountDue)
                }).ToList();

                dataGridView1.DataSource = displayList;
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
