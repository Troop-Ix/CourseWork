namespace LogInSystem.HelpingForms
{
    partial class AddPaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PaidAmount = new System.Windows.Forms.NumericUpDown();
            this.AmountDue = new System.Windows.Forms.NumericUpDown();
            this.LastDatePayment = new System.Windows.Forms.DateTimePicker();
            this.StudentsIDList = new System.Windows.Forms.ComboBox();
            this.PaymentItemsList = new System.Windows.Forms.ComboBox();
            this.Add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PaidAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountDue)).BeginInit();
            this.SuspendLayout();
            // 
            // PaidAmount
            // 
            this.PaidAmount.DecimalPlaces = 2;
            this.PaidAmount.Location = new System.Drawing.Point(17, 143);
            this.PaidAmount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.Size = new System.Drawing.Size(145, 20);
            this.PaidAmount.TabIndex = 0;
            // 
            // AmountDue
            // 
            this.AmountDue.DecimalPlaces = 2;
            this.AmountDue.Location = new System.Drawing.Point(242, 143);
            this.AmountDue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.AmountDue.Name = "AmountDue";
            this.AmountDue.Size = new System.Drawing.Size(120, 20);
            this.AmountDue.TabIndex = 1;
            // 
            // LastDatePayment
            // 
            this.LastDatePayment.Location = new System.Drawing.Point(462, 97);
            this.LastDatePayment.Name = "LastDatePayment";
            this.LastDatePayment.ShowCheckBox = true;
            this.LastDatePayment.Size = new System.Drawing.Size(200, 20);
            this.LastDatePayment.TabIndex = 2;
            // 
            // StudentsIDList
            // 
            this.StudentsIDList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StudentsIDList.FormattingEnabled = true;
            this.StudentsIDList.Location = new System.Drawing.Point(17, 85);
            this.StudentsIDList.Name = "StudentsIDList";
            this.StudentsIDList.Size = new System.Drawing.Size(176, 21);
            this.StudentsIDList.TabIndex = 3;
            // 
            // PaymentItemsList
            // 
            this.PaymentItemsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PaymentItemsList.FormattingEnabled = true;
            this.PaymentItemsList.Location = new System.Drawing.Point(242, 85);
            this.PaymentItemsList.Name = "PaymentItemsList";
            this.PaymentItemsList.Size = new System.Drawing.Size(207, 21);
            this.PaymentItemsList.TabIndex = 4;
            // 
            // Add
            // 
            this.Add.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.Location = new System.Drawing.Point(334, 186);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(99, 34);
            this.Add.TabIndex = 5;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Список ID студентов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(238, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Список предметов оплат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Внесенная сумма";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(238, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Список ID студентов";
            // 
            // AddPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 254);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.PaymentItemsList);
            this.Controls.Add(this.StudentsIDList);
            this.Controls.Add(this.LastDatePayment);
            this.Controls.Add(this.AmountDue);
            this.Controls.Add(this.PaidAmount);
            this.Name = "AddPaymentForm";
            this.Text = "Добавление оплаты";
            ((System.ComponentModel.ISupportInitialize)(this.PaidAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmountDue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown PaidAmount;
        private System.Windows.Forms.NumericUpDown AmountDue;
        private System.Windows.Forms.DateTimePicker LastDatePayment;
        private System.Windows.Forms.ComboBox StudentsIDList;
        private System.Windows.Forms.ComboBox PaymentItemsList;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}