namespace LogInSystem
{
    partial class AdministratorForm
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
            this.Inventorypanel = new System.Windows.Forms.Panel();
            this.Studentpanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Role = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RemoveItem = new System.Windows.Forms.Button();
            this.ChangeStateOfItem = new System.Windows.Forms.Button();
            this.AddItem = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GetDebtors = new System.Windows.Forms.Button();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Inventorypanel
            // 
            this.Inventorypanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Inventorypanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Inventorypanel.Location = new System.Drawing.Point(21, 27);
            this.Inventorypanel.Name = "Inventorypanel";
            this.Inventorypanel.Size = new System.Drawing.Size(1350, 580);
            this.Inventorypanel.TabIndex = 0;
            // 
            // Studentpanel
            // 
            this.Studentpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Studentpanel.Location = new System.Drawing.Point(20, 20);
            this.Studentpanel.Name = "Studentpanel";
            this.Studentpanel.Size = new System.Drawing.Size(1350, 550);
            this.Studentpanel.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.FIO);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(820, 10);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(350, 45);
            this.panel6.TabIndex = 5;
            // 
            // FIO
            // 
            this.FIO.AutoSize = true;
            this.FIO.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIO.Location = new System.Drawing.Point(58, 12);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(0, 21);
            this.FIO.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ФИО:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.Role);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Location = new System.Drawing.Point(1175, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 45);
            this.panel7.TabIndex = 6;
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Role.ForeColor = System.Drawing.Color.Red;
            this.Role.Location = new System.Drawing.Point(42, 13);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(0, 21);
            this.Role.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Вы:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 65);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(20, 10);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1395, 739);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.RemoveItem);
            this.tabPage1.Controls.Add(this.ChangeStateOfItem);
            this.tabPage1.Controls.Add(this.AddItem);
            this.tabPage1.Controls.Add(this.Inventorypanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1387, 699);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Инвентарь";
            // 
            // RemoveItem
            // 
            this.RemoveItem.BackColor = System.Drawing.Color.MediumBlue;
            this.RemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.RemoveItem.ForeColor = System.Drawing.Color.White;
            this.RemoveItem.Location = new System.Drawing.Point(870, 620);
            this.RemoveItem.Name = "RemoveItem";
            this.RemoveItem.Size = new System.Drawing.Size(300, 45);
            this.RemoveItem.TabIndex = 3;
            this.RemoveItem.Text = "Удалить предмет";
            this.RemoveItem.UseVisualStyleBackColor = false;
            this.RemoveItem.Click += new System.EventHandler(this.RemoveItem_Click);
            // 
            // ChangeStateOfItem
            // 
            this.ChangeStateOfItem.BackColor = System.Drawing.Color.MediumBlue;
            this.ChangeStateOfItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChangeStateOfItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.ChangeStateOfItem.ForeColor = System.Drawing.Color.White;
            this.ChangeStateOfItem.Location = new System.Drawing.Point(530, 620);
            this.ChangeStateOfItem.Name = "ChangeStateOfItem";
            this.ChangeStateOfItem.Size = new System.Drawing.Size(320, 45);
            this.ChangeStateOfItem.TabIndex = 2;
            this.ChangeStateOfItem.Text = "Изменить состояние предмета";
            this.ChangeStateOfItem.UseVisualStyleBackColor = false;
            this.ChangeStateOfItem.Click += new System.EventHandler(this.ChangeStateOfItem_Click);
            // 
            // AddItem
            // 
            this.AddItem.BackColor = System.Drawing.Color.MediumBlue;
            this.AddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddItem.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.AddItem.ForeColor = System.Drawing.Color.White;
            this.AddItem.Location = new System.Drawing.Point(210, 620);
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(300, 45);
            this.AddItem.TabIndex = 1;
            this.AddItem.Text = "Добавить предмет";
            this.AddItem.UseVisualStyleBackColor = false;
            this.AddItem.Click += new System.EventHandler(this.AddItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3.Controls.Add(this.GetDebtors);
            this.tabPage3.Controls.Add(this.Studentpanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 36);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1387, 699);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Студенты";
            // 
            // GetDebtors
            // 
            this.GetDebtors.BackColor = System.Drawing.Color.MediumBlue;
            this.GetDebtors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetDebtors.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.GetDebtors.ForeColor = System.Drawing.Color.White;
            this.GetDebtors.Location = new System.Drawing.Point(550, 590);
            this.GetDebtors.Name = "GetDebtors";
            this.GetDebtors.Size = new System.Drawing.Size(280, 45);
            this.GetDebtors.TabIndex = 0;
            this.GetDebtors.Text = "Получить должников";
            this.GetDebtors.UseVisualStyleBackColor = false;
            this.GetDebtors.Click += new System.EventHandler(this.GetDebtors_Click);
            // 
            // AdministratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1395, 804);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Name = "AdministratorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администратор";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel Inventorypanel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel Studentpanel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label Role;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label FIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChangeStateOfItem;
        private System.Windows.Forms.Button AddItem;
        private System.Windows.Forms.Button RemoveItem;
        private System.Windows.Forms.Button GetDebtors;
    }
}