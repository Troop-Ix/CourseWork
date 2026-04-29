namespace LogInSystem.HelpingForms
{
    partial class SetBenefitForStudentForm
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
            this.DateIssue = new System.Windows.Forms.DateTimePicker();
            this.BenefitsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateIssue
            // 
            this.DateIssue.Location = new System.Drawing.Point(615, 112);
            this.DateIssue.Name = "DateIssue";
            this.DateIssue.Size = new System.Drawing.Size(200, 20);
            this.DateIssue.TabIndex = 0;
            // 
            // BenefitsList
            // 
            this.BenefitsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BenefitsList.FormattingEnabled = true;
            this.BenefitsList.Location = new System.Drawing.Point(206, 111);
            this.BenefitsList.Name = "BenefitsList";
            this.BenefitsList.Size = new System.Drawing.Size(121, 21);
            this.BenefitsList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(25, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите ID льготы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(354, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите дату выдачи льготы";
            // 
            // Set
            // 
            this.Set.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Set.Location = new System.Drawing.Point(332, 189);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(113, 35);
            this.Set.TabIndex = 4;
            this.Set.Text = "Установить";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // SetBenefitForStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 258);
            this.Controls.Add(this.Set);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BenefitsList);
            this.Controls.Add(this.DateIssue);
            this.Name = "SetBenefitForStudentForm";
            this.Text = "Добавление льготы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DateIssue;
        private System.Windows.Forms.ComboBox BenefitsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Set;
    }
}