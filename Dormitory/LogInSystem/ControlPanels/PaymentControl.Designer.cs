using System.Drawing;
using System.Windows.Forms;

namespace LogInSystem
{
    partial class PaymentControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.PaymentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPaymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PaymentID,
            this.StudentID,
            this.PaidAmount,
            this.AmountDue,
            this.PaymentItemID,
            this.LastPaymentDate});
            this.dataGridView1.Location = new System.Drawing.Point(13, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 337);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(301, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Оплаты";
            // 
            // PaymentID
            // 
            this.PaymentID.DataPropertyName = "PaymentID";
            this.PaymentID.HeaderText = "ID";
            this.PaymentID.Name = "PaymentID";
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "ID студента";
            this.StudentID.Name = "StudentID";
            // 
            // PaidAmount
            // 
            this.PaidAmount.DataPropertyName = "PaidAmount";
            this.PaidAmount.HeaderText = "Внесено";
            this.PaidAmount.Name = "PaidAmount";
            // 
            // AmountDue
            // 
            this.AmountDue.DataPropertyName = "AmountDue";
            this.AmountDue.HeaderText = "Сумма к оплате";
            this.AmountDue.Name = "AmountDue";
            // 
            // PaymentItemID
            // 
            this.PaymentItemID.DataPropertyName = "PaymentItemID";
            this.PaymentItemID.HeaderText = "Предмет оплаты";
            this.PaymentItemID.Name = "PaymentItemID";
            // 
            // LastPaymentDate
            // 
            this.LastPaymentDate.DataPropertyName = "LastPaymentDate";
            this.LastPaymentDate.HeaderText = "Дата последней оплаты";
            this.LastPaymentDate.Name = "LastPaymentDate";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.PName});
            this.dataGridView2.Location = new System.Drawing.Point(726, 97);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(240, 179);
            this.dataGridView2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(774, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Предметы оплат";
            // 
            // ItemID
            // 
            this.ItemID.DataPropertyName = "PaymentItemID";
            this.ItemID.HeaderText = "ID";
            this.ItemID.Name = "ItemID";
            // 
            // PName
            // 
            this.PName.DataPropertyName = "Name";
            this.PName.HeaderText = "Название";
            this.PName.Name = "PName";
            // 
            // PaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PaymentControl";
            this.Size = new System.Drawing.Size(982, 456);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn PaymentID;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn PaidAmount;
        private DataGridViewTextBoxColumn AmountDue;
        private DataGridViewTextBoxColumn PaymentItemID;
        private DataGridViewTextBoxColumn LastPaymentDate;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn ItemID;
        private DataGridViewTextBoxColumn PName;
        private Label label2;
    }
}
