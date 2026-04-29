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
    public partial class AddPaymentForm : Form
    {
        StudentsService _studentsService;
        PaymentItemService _paymentItemService;
        PaymentService _paymentService;
        public AddPaymentForm(StudentsService studentsService, PaymentItemService paymentItemService, PaymentService paymentService)
        {
            InitializeComponent();
            _studentsService = studentsService;
            _paymentItemService = paymentItemService;
            _paymentService = paymentService;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        private async void LoadInitialization()
        {
            var students = await _studentsService.GetStudents();
            var displayList = students.Select(s => new {
                Id = s.StudentID,
                FullName = $"{s.Surname} {s.Name} {s.Middlename}"
            }).ToList();

            var paymentItems = await _paymentItemService.GetPaymentItems();

            StudentsIDList.DataSource = displayList.ToList();
            PaymentItemsList.DataSource = paymentItems.ToList();

            PaymentItemsList.DisplayMember = "Name";
            PaymentItemsList.ValueMember = "PaymentItemID";

            StudentsIDList.DataSource = displayList;
            StudentsIDList.DisplayMember = "FullName";
            StudentsIDList.ValueMember = "Id";
            if (displayList.Any() && paymentItems.Any())
            {
                Add.Enabled = true;
                StudentsIDList.SelectedIndex = 0;
                PaymentItemsList.SelectedIndex = 0;
            }
            else
            {
                Add.Enabled = false;
            }
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            if (PaidAmount.Value > AmountDue.Value)
            {
                MessageBox.Show("Внесенная сумма не может быть больше необходимой");
                return;
            }

            if (AmountDue.Value == 0)
            {
                MessageBox.Show("Необходимая оплата не может быть нулевой");
                return;
            }

            if (PaymentItemsList.SelectedValue == null || StudentsIDList.SelectedValue == null)
            {
                MessageBox.Show("Выберите необходимые данные");
                return;
            }

            DateTime? lastDate = LastDatePayment.Checked ? LastDatePayment.Value : (DateTime?)null;
            int paymentItemID = (int)PaymentItemsList.SelectedValue;
            int studentID = (int)StudentsIDList.SelectedValue;

            try
            {
                await _paymentService.AddPayment(studentID, PaidAmount.Value, AmountDue.Value, paymentItemID, lastDate);
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
