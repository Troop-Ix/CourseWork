namespace LogInSystem.HelpingForms
{
    partial class ChangePaymentForm
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
            this.ChangeAmount = new System.Windows.Forms.NumericUpDown();
            this.ChangeLastDate = new System.Windows.Forms.DateTimePicker();
            this.Change = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChangeAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // ChangeAmount
            // 
            this.ChangeAmount.DecimalPlaces = 2;
            this.ChangeAmount.Location = new System.Drawing.Point(69, 91);
            this.ChangeAmount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ChangeAmount.Name = "ChangeAmount";
            this.ChangeAmount.Size = new System.Drawing.Size(120, 20);
            this.ChangeAmount.TabIndex = 0;
            // 
            // ChangeLastDate
            // 
            this.ChangeLastDate.Location = new System.Drawing.Point(260, 92);
            this.ChangeLastDate.Name = "ChangeLastDate";
            this.ChangeLastDate.Size = new System.Drawing.Size(200, 20);
            this.ChangeLastDate.TabIndex = 1;
            // 
            // Change
            // 
            this.Change.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Change.Location = new System.Drawing.Point(175, 141);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(122, 44);
            this.Change.TabIndex = 2;
            this.Change.Text = "Изменить";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(55, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Внесенная сумма";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(261, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Дата последней оплаты";
            // 
            // ChangePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 217);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.ChangeLastDate);
            this.Controls.Add(this.ChangeAmount);
            this.Name = "ChangePaymentForm";
            this.Text = "Изменение оплаты";
            ((System.ComponentModel.ISupportInitialize)(this.ChangeAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ChangeAmount;
        private System.Windows.Forms.DateTimePicker ChangeLastDate;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}