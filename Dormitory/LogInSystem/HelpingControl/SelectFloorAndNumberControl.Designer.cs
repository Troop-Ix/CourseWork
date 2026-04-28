namespace LogInSystem.HelpingControl
{
    partial class SelectFloorAndNumberControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FloorsList = new System.Windows.Forms.ComboBox();
            this.NumbersList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(285, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выберите номер";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выберите этаж";
            // 
            // FloorsList
            // 
            this.FloorsList.FormattingEnabled = true;
            this.FloorsList.Location = new System.Drawing.Point(145, 67);
            this.FloorsList.Name = "FloorsList";
            this.FloorsList.Size = new System.Drawing.Size(121, 21);
            this.FloorsList.TabIndex = 5;
            this.FloorsList.SelectedIndexChanged += new System.EventHandler(this.FloorsList_SelectedIndexChanged_1);
            // 
            // NumbersList
            // 
            this.NumbersList.FormattingEnabled = true;
            this.NumbersList.Location = new System.Drawing.Point(435, 67);
            this.NumbersList.Name = "NumbersList";
            this.NumbersList.Size = new System.Drawing.Size(121, 21);
            this.NumbersList.TabIndex = 4;
            // 
            // SelectFloorAndNumberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FloorsList);
            this.Controls.Add(this.NumbersList);
            this.Name = "SelectFloorAndNumberControl";
            this.Size = new System.Drawing.Size(611, 132);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FloorsList;
        private System.Windows.Forms.ComboBox NumbersList;
    }
}
