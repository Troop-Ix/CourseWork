using DormitoryObjects;
using DormitoryObjects.DTO;
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
    /// <summary>
    /// Окно для изменения заданной оплаты
    /// </summary>
    public partial class ChangePaymentForm : Form
    {
        int _paymentID;
        PaymentService _paymentService;
        PaymentDTO payment;
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
        /// <summary>
        /// Установление значение и минимума для внесённой суммы оплаты
        /// </summary>
        private async void LoadInitialization()
        {
            try
            {
                payment = await _paymentService.GetPaymentByID(_paymentID);
                ChangeAmount.Value = payment.PaidAmount;
                ChangeAmount.Minimum = payment.PaidAmount;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке оплаты: {ex.Message}");
                Change.Enabled = false;
            }
        }
        /// <summary>
        /// Изменение информации по оплате
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
