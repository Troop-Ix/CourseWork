using System.Drawing;
using System.Windows.Forms;

namespace LogInSystem
{
    partial class CommandantForm
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
            this.RoomPanel = new System.Windows.Forms.Panel();
            this.Paymentpanel = new System.Windows.Forms.Panel();
            this.Benefitpanel = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.FIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.Role = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SetItemForRoom = new System.Windows.Forms.Button();
            this.RemoveItemFromRoom = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RemoveBenefitsFromStudent = new System.Windows.Forms.Button();
            this.AddBenefit = new System.Windows.Forms.Button();
            this.SetRoomForStudent = new System.Windows.Forms.Button();
            this.EvictStudentFromRoom = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RemovePayment = new System.Windows.Forms.Button();
            this.ChangePayment = new System.Windows.Forms.Button();
            this.AddPayment = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.Planpanel = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Inventorypanel
            // 
            this.Inventorypanel.Location = new System.Drawing.Point(244, 29);
            this.Inventorypanel.Name = "Inventorypanel";
            this.Inventorypanel.Size = new System.Drawing.Size(991, 625);
            this.Inventorypanel.TabIndex = 0;
            // 
            // Studentpanel
            // 
            this.Studentpanel.Location = new System.Drawing.Point(126, 46);
            this.Studentpanel.Name = "Studentpanel";
            this.Studentpanel.Size = new System.Drawing.Size(1065, 384);
            this.Studentpanel.TabIndex = 1;
            // 
            // RoomPanel
            // 
            this.RoomPanel.Location = new System.Drawing.Point(322, 6);
            this.RoomPanel.Name = "RoomPanel";
            this.RoomPanel.Size = new System.Drawing.Size(823, 408);
            this.RoomPanel.TabIndex = 2;
            // 
            // Paymentpanel
            // 
            this.Paymentpanel.Location = new System.Drawing.Point(227, 57);
            this.Paymentpanel.Name = "Paymentpanel";
            this.Paymentpanel.Size = new System.Drawing.Size(1027, 501);
            this.Paymentpanel.TabIndex = 3;
            // 
            // Benefitpanel
            // 
            this.Benefitpanel.Location = new System.Drawing.Point(418, 30);
            this.Benefitpanel.Name = "Benefitpanel";
            this.Benefitpanel.Size = new System.Drawing.Size(551, 291);
            this.Benefitpanel.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.FIO);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(484, 8);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(298, 48);
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
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.Role);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Location = new System.Drawing.Point(778, 8);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(152, 48);
            this.panel7.TabIndex = 6;
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Role.ForeColor = System.Drawing.Color.DodgerBlue;
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(8, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1375, 742);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SetItemForRoom);
            this.tabPage1.Controls.Add(this.RemoveItemFromRoom);
            this.tabPage1.Controls.Add(this.Inventorypanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1367, 716);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Инвентарь";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SetItemForRoom
            // 
            this.SetItemForRoom.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetItemForRoom.Location = new System.Drawing.Point(457, 660);
            this.SetItemForRoom.Name = "SetItemForRoom";
            this.SetItemForRoom.Size = new System.Drawing.Size(268, 44);
            this.SetItemForRoom.TabIndex = 1;
            this.SetItemForRoom.Text = "Назначить предмет на комнату";
            this.SetItemForRoom.UseVisualStyleBackColor = true;
            this.SetItemForRoom.Click += new System.EventHandler(this.SetItemForRoom_Click);
            // 
            // RemoveItemFromRoom
            // 
            this.RemoveItemFromRoom.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveItemFromRoom.Location = new System.Drawing.Point(813, 660);
            this.RemoveItemFromRoom.Name = "RemoveItemFromRoom";
            this.RemoveItemFromRoom.Size = new System.Drawing.Size(245, 44);
            this.RemoveItemFromRoom.TabIndex = 2;
            this.RemoveItemFromRoom.Text = "Убрать предмет из комнаты";
            this.RemoveItemFromRoom.UseVisualStyleBackColor = true;
            this.RemoveItemFromRoom.Click += new System.EventHandler(this.RemoveItemFromRoom_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RoomPanel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1367, 716);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Комнаты";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RemoveBenefitsFromStudent);
            this.tabPage3.Controls.Add(this.AddBenefit);
            this.tabPage3.Controls.Add(this.SetRoomForStudent);
            this.tabPage3.Controls.Add(this.EvictStudentFromRoom);
            this.tabPage3.Controls.Add(this.Studentpanel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1367, 716);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Студенты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RemoveBenefitsFromStudent
            // 
            this.RemoveBenefitsFromStudent.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveBenefitsFromStudent.Location = new System.Drawing.Point(975, 464);
            this.RemoveBenefitsFromStudent.Name = "RemoveBenefitsFromStudent";
            this.RemoveBenefitsFromStudent.Size = new System.Drawing.Size(216, 40);
            this.RemoveBenefitsFromStudent.TabIndex = 5;
            this.RemoveBenefitsFromStudent.Text = "Убрать льготы студента";
            this.RemoveBenefitsFromStudent.UseVisualStyleBackColor = true;
            this.RemoveBenefitsFromStudent.Click += new System.EventHandler(this.RemoveBenefitsFromStudent_Click);
            // 
            // AddBenefit
            // 
            this.AddBenefit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBenefit.Location = new System.Drawing.Point(700, 464);
            this.AddBenefit.Name = "AddBenefit";
            this.AddBenefit.Size = new System.Drawing.Size(243, 40);
            this.AddBenefit.TabIndex = 4;
            this.AddBenefit.Text = "Добавить льготу студенту";
            this.AddBenefit.UseVisualStyleBackColor = true;
            this.AddBenefit.Click += new System.EventHandler(this.AddBenefit_Click);
            // 
            // SetRoomForStudent
            // 
            this.SetRoomForStudent.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetRoomForStudent.Location = new System.Drawing.Point(449, 464);
            this.SetRoomForStudent.Name = "SetRoomForStudent";
            this.SetRoomForStudent.Size = new System.Drawing.Size(204, 40);
            this.SetRoomForStudent.TabIndex = 3;
            this.SetRoomForStudent.Text = "Заселить студента";
            this.SetRoomForStudent.UseVisualStyleBackColor = true;
            this.SetRoomForStudent.Click += new System.EventHandler(this.SetRoomForStudent_Click);
            // 
            // EvictStudentFromRoom
            // 
            this.EvictStudentFromRoom.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EvictStudentFromRoom.Location = new System.Drawing.Point(126, 464);
            this.EvictStudentFromRoom.Name = "EvictStudentFromRoom";
            this.EvictStudentFromRoom.Size = new System.Drawing.Size(271, 40);
            this.EvictStudentFromRoom.TabIndex = 2;
            this.EvictStudentFromRoom.Text = "Выселить студента из комнаты";
            this.EvictStudentFromRoom.UseVisualStyleBackColor = true;
            this.EvictStudentFromRoom.Click += new System.EventHandler(this.EvictStudentFromRoom_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.RemovePayment);
            this.tabPage4.Controls.Add(this.ChangePayment);
            this.tabPage4.Controls.Add(this.AddPayment);
            this.tabPage4.Controls.Add(this.Paymentpanel);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1367, 716);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Оплаты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // RemovePayment
            // 
            this.RemovePayment.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemovePayment.Location = new System.Drawing.Point(894, 585);
            this.RemovePayment.Name = "RemovePayment";
            this.RemovePayment.Size = new System.Drawing.Size(162, 34);
            this.RemovePayment.TabIndex = 6;
            this.RemovePayment.Text = "Удалить оплату";
            this.RemovePayment.UseVisualStyleBackColor = true;
            this.RemovePayment.Click += new System.EventHandler(this.RemovePayment_Click);
            // 
            // ChangePayment
            // 
            this.ChangePayment.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChangePayment.Location = new System.Drawing.Point(587, 585);
            this.ChangePayment.Name = "ChangePayment";
            this.ChangePayment.Size = new System.Drawing.Size(183, 33);
            this.ChangePayment.TabIndex = 5;
            this.ChangePayment.Text = "Изменить оплату";
            this.ChangePayment.UseVisualStyleBackColor = true;
            this.ChangePayment.Click += new System.EventHandler(this.ChangePayment_Click);
            // 
            // AddPayment
            // 
            this.AddPayment.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddPayment.Location = new System.Drawing.Point(293, 585);
            this.AddPayment.Name = "AddPayment";
            this.AddPayment.Size = new System.Drawing.Size(192, 33);
            this.AddPayment.TabIndex = 4;
            this.AddPayment.Text = "Добавить Оплату";
            this.AddPayment.UseVisualStyleBackColor = true;
            this.AddPayment.Click += new System.EventHandler(this.AddPayment_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.Benefitpanel);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1367, 716);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Виды льгот";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.Planpanel);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1367, 716);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Планы этажей";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // Planpanel
            // 
            this.Planpanel.Location = new System.Drawing.Point(270, 38);
            this.Planpanel.Name = "Planpanel";
            this.Planpanel.Size = new System.Drawing.Size(904, 557);
            this.Planpanel.TabIndex = 0;
            // 
            // CommandantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 804);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Name = "CommandantForm";
            this.Text = "Комендант";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel Inventorypanel;
        private Panel Studentpanel;
        private Panel RoomPanel;
        private Panel Paymentpanel;
        private Panel Benefitpanel;
        private Panel panel6;
        private Label FIO;
        private Label label1;
        private Panel panel7;
        private Label Role;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Panel Planpanel;
        private Button RemoveItemFromRoom;
        private Button SetItemForRoom;
        private Button EvictStudentFromRoom;
        private Button SetRoomForStudent;
        private Button AddBenefit;
        private Button RemoveBenefitsFromStudent;
        private Button RemovePayment;
        private Button ChangePayment;
        private Button AddPayment;
    }
}