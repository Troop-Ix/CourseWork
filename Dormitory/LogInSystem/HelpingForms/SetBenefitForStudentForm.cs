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
        private async void LoadInitialization()
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

        private async void Set_Click(object sender, EventArgs e)
        {
            if (BenefitsList.SelectedValue != null)
            {
                int benefitID = (int)BenefitsList.SelectedValue;
                DateTime dateIssue = DateIssue.Value;

                await _studentBenefitService.SetBenefitForStudent(_studentId, benefitID, dateIssue);
                this.Close();
            }
            else
            {
                MessageBox.Show("Не выбран тип льготы.");
            }
        }
    }
}
