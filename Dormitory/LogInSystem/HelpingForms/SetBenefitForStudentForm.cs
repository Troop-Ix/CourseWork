using DormitoryObjects.Services;
using LogInSystem.HelpingControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace LogInSystem.HelpingForms
{
    /// <summary>
    /// Окно для добавления льготы студенту
    /// </summary>
    public partial class SetBenefitForStudentForm : Form
    {
        BenefitTypeService _benefitTypeService;
        StudentBenefitService _studentBenefitService;
        int _studentId;
        public SetBenefitForStudentForm(BenefitTypeService benefitTypeService, StudentBenefitService studentBenefitService, int studentID)
        {
            InitializeComponent();
            _benefitTypeService = benefitTypeService;
            _studentBenefitService = studentBenefitService;
            _studentId = studentID;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        /// <summary>
        /// Инициализация списка видов оплат
        /// </summary>
        private async void LoadInitialization()
        {
            try
            {
                var benefits = await _benefitTypeService.GetBenefitTypes();
                BenefitsList.DisplayMember = "Name";
                BenefitsList.ValueMember = "BenefitID";
                BenefitsList.DataSource = benefits.ToList();
                if (benefits.Any())
                {
                    Set.Enabled = true;
                    BenefitsList.SelectedIndex = 0;
                }
                else
                {
                    Set.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов льгот: {ex.Message}");
                Set.Enabled = false;
            }
        }
        /// <summary>
        /// Добавление льготы студенту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Set_Click(object sender, EventArgs e)
        {
            if (BenefitsList.SelectedValue != null)
            {
                int benefitID = (int)BenefitsList.SelectedValue;
                DateTime dateIssue = DateIssue.Value;
                try
                {
                    await _studentBenefitService.SetBenefitForStudent(_studentId, benefitID, dateIssue);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось изменить данные: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Не выбран тип льготы.");
            }
        }
    }
}
