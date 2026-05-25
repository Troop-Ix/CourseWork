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
    /// Пользовательский элемент управления для отображения таблиц с информацией по оплатам и предметам оплат
    /// 
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
            this.dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }
        /// <summary>
        /// Одновременная загрузка всей информации по всем таблицам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PaymentControl_Load(object sender, EventArgs e)
        {
            try
            {
                await Task.WhenAll(
                    LoadDataGrid(() => _paymentService.GetPayments(), dataGridView1),
                    LoadDataGrid(() => _paymentItemService.GetPaymentItems(), dataGridView2)
                    );
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
        /// Загрузка данных в выбранную таблицу с помощью заданного метода
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataFunc">Метод для получения данных</param>
        /// <param name="dataGrid">Таблица для заполнения полученными данными</param>
        /// <returns></returns>
        private async Task LoadDataGrid<T>(Func<Task<IEnumerable<T>>> dataFunc, DataGridView dataGrid )
        {
            var data = await dataFunc();
            dataGrid.DataSource = data;
        }
        /// <summary>
        /// Загрузка информации по оплатам
        /// </summary>
        /// <returns></returns>
        public async Task LoadPayments()
        {
            try
            {
                await LoadDataGrid(() => _paymentService.GetPayments(), dataGridView1);
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
        /// Возврат id из выбранной строкм в таблице оплат
        /// </summary>
        /// <returns></returns>
        public int? GetSelectedPaymentID()
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
        /// Форматирование ячеек таблицы оплат для корректного отображения данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "StudentID" && e.RowIndex >= 0)
            {
                var payment = dataGridView1.Rows[e.RowIndex].DataBoundItem as PaymentDTO;
                if (payment != null && payment.Student != null)
                {
                    e.Value = payment.Student.StudentID.ToString();
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "-";
                    e.FormattingApplied = true;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "PaymentItemID" && e.RowIndex >= 0)
            {
                var payment = dataGridView1.Rows[e.RowIndex].DataBoundItem as PaymentDTO;
                if (payment != null && payment.PaymentItem != null)
                {
                    e.Value = payment.PaymentItem.PaymentItemID.ToString();
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
