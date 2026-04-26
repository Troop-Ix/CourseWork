namespace LogInSystem
{
    partial class FloorsPlans
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
            this.FloorPanel = new System.Windows.Forms.Panel();
            this.FloorsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FloorPanel
            // 
            this.FloorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FloorPanel.Location = new System.Drawing.Point(80, 68);
            this.FloorPanel.Name = "FloorPanel";
            this.FloorPanel.Size = new System.Drawing.Size(660, 321);
            this.FloorPanel.TabIndex = 0;
            // 
            // FloorsList
            // 
            this.FloorsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FloorsList.FormattingEnabled = true;
            this.FloorsList.Location = new System.Drawing.Point(481, 27);
            this.FloorsList.Name = "FloorsList";
            this.FloorsList.Size = new System.Drawing.Size(121, 21);
            this.FloorsList.TabIndex = 1;
            this.FloorsList.SelectedIndexChanged += new System.EventHandler(this.FloorsList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(129, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите этажа для отображения плана";
            // 
            // FloorsPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FloorsList);
            this.Controls.Add(this.FloorPanel);
            this.Name = "FloorsPlans";
            this.Size = new System.Drawing.Size(822, 448);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FloorPanel;
        private System.Windows.Forms.ComboBox FloorsList;
        private System.Windows.Forms.Label label1;
    }
}
