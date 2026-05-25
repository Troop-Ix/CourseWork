using DormitoryObjects;
using DormitoryObjects.DTO;
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
    /// Пользовательский элемент управления для отображения таблиц с информацией по студентам и типам льгот
    /// 
    public partial class StudentControl : UserControl
    {
        StudentsService _studentsService;
        BenefitTypeService _benefitTypeService;

        public StudentControl(StudentsService studentsService, BenefitTypeService benefitTypeService)
        {
            InitializeComponent();
            _studentsService = studentsService;
            _benefitTypeService = benefitTypeService;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            this.Load += StudentsControl_Load;
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private async void StudentsControl_Load(object sender, EventArgs e)
        {
            await LoadStudents();
            await LoadBenefitType();
        }
        /// <summary>
        /// Загрузка данных о студентах
        /// </summary>
        /// <returns></returns>
        public async Task LoadStudents()
        {
            try
            {
                string surname = EnterSurname.Text;
                var students = await _studentsService.GetStudentsBySurname(surname);
                dataGridView1.DataSource = students?.ToList() ?? new List<StudentDTO>();
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
        /// Загрузка данных о типах льгот
        /// </summary>
        /// <returns></returns>
        private async Task LoadBenefitType()
        {
            try
            {
                var benefitTypes = await _benefitTypeService.GetBenefitTypes();
                dataGridView2.DataSource = benefitTypes.ToList();
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
        /// Отображение информации о студентах в зависимости от введённых символов в поле 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EnterSurname_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string surname = EnterSurname.Text;
                var students = await _studentsService.GetStudentsBySurname(surname);
                dataGridView1.DataSource = students?.ToList() ?? new List<StudentDTO>();
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
        /// Возврат id из выбранной строкм в таблице студентов
        /// </summary>
        /// <returns></returns>
        public int? GetSelectedStudentID()
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
        /// Форматирование ячеек таблицы комнат для корректного отображения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "RoomNumber" && e.RowIndex >= 0)
            {
                var student = dataGridView1.Rows[e.RowIndex].DataBoundItem as StudentDTO;
                if (student != null && student.Room != null)
                {
                    e.Value = student.Room.Number.ToString();
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "BenefitIds" && e.RowIndex >= 0)
            {
                var student = dataGridView1.Rows[e.RowIndex].DataBoundItem as StudentDTO;
                if (student != null && student.StudentBenefits != null && student.StudentBenefits.Any())
                {
                    var ids = student.StudentBenefits.Select(b => b.BenefitType.BenefitID.ToString());
                    e.Value = string.Join(", ", ids);
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}