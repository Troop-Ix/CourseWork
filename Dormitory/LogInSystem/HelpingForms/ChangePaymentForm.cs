using DormitoryObjects;
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
    public partial class ChangePaymentForm : Form
    {
        int _paymentID;
        PaymentService _paymentService;
        Payment payment;
        public ChangePaymentForm(int paymentID, PaymentService paymentService)
        {
            InitializeComponent();
            _paymentID = paymentID;
            _paymentService = paymentService;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadInitialization();
        }
        private async void LoadInitialization()
        {
            payment = await _paymentService.GetPaymentByID(_paymentID);
            ChangeAmount.Value = payment.PaidAmount;
            ChangeAmount.Minimum = payment.PaidAmount;
        }
        private async void Change_Click(object sender, EventArgs e)
        {
            if (ChangeAmount.Value > payment.AmountDue)
            {
                MessageBox.Show("Внесенная сумма не может быть больше необходимой");
                return;
            }
            DateTime lastDate = ChangeLastDate.Value;
            decimal paidAmount = ChangeAmount.Value;
            try
            {
                await _paymentService.ChangePayment(_paymentID, paidAmount, lastDate);
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
