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
    public partial class PaymentControl : UserControl
    {
        PaymentService _paymentService;
        PaymentItemService _paymentItemService;
        public PaymentControl(PaymentService paymentService, PaymentItemService paymentItemService)
        {
            InitializeComponent();
            _paymentService = paymentService;
            _paymentItemService=paymentItemService;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;

            this.Load += PaymentControl_Load;
        }
        private async void PaymentControl_Load(object sender, EventArgs e)
        {
            await Task.WhenAll(
                LoadDataGrid(()=>  _paymentService.GetPayments(), dataGridView1),
                LoadDataGrid(() => _paymentItemService.GetPaymentItems(), dataGridView2)
                );
        }
        private async Task LoadDataGrid<T>(Func<Task<IEnumerable<T>>> dataFunc, DataGridView dataGrid )
        {
            var data = await dataFunc();
            dataGrid.DataSource = data;
        }
        private async Task LoadPayments()
        {
            try
            {
                var payments = await _paymentService.GetPayments();
                dataGridView1.DataSource = payments.ToList();
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
