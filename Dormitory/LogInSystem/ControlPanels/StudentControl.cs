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

namespace LogInSystem
{
    public partial class StudentControl : UserControl
    {
        StudentsService _studentsService;
        public StudentControl(StudentsService studentsService)
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
                string surname = EnterSurname.Text;
                var students = await _studentsService.GetStudentsBySurname(surname);
                var displayList = students.Select(s => new
                {
                    s.StudentID,
                    s.Surname,
                    s.Name,
                    s.Middlename,
                    RoomID = s.RoomID?.ToString() ?? "-",
                    s.Birthdate,
                    s.PhoneNumber,
                    s.Faculty,
                    s.Group,
                    BenefitIds = (s.StudentBenefits != null && s.StudentBenefits.Any())
                    ? string.Join(", ", s.StudentBenefits.Select(b => b.BenefitID))
                    : "-"
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

        private async void EnterSurname_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string surname = EnterSurname.Text;
                var students = await _studentsService.GetStudentsBySurname(surname);
                var displayList = students.Select(s => new
                {
                    s.StudentID,
                    s.Surname,
                    s.Name,
                    s.Middlename,
                    RoomID = s.RoomID?.ToString() ?? "-",
                    s.Birthdate,
                    s.PhoneNumber,
                    s.Faculty,
                    s.Group,
                    BenefitIds = (s.StudentBenefits != null && s.StudentBenefits.Any())
                    ? string.Join(", ", s.StudentBenefits.Select(b => b.BenefitID))
                    : "-"
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

        public  int? GetSelectedStudentID()
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
    }
}
