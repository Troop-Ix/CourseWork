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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(244, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 625);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(126, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1065, 384);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(322, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(823, 408);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(227, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1027, 501);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(418, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(551, 291);
            this.panel5.TabIndex = 4;
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
            this.tabPage1.Controls.Add(this.panel1);
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
            this.tabPage2.Controls.Add(this.panel3);
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
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1367, 716);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Студенты";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1367, 716);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Оплаты";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1367, 716);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Виды льгот";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel8);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1367, 716);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Планы этажей";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(270, 38);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(904, 557);
            this.panel8.TabIndex = 0;
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
            this.Text = "CommandantForm";
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

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
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
        private Panel panel8;
        private Button RemoveItemFromRoom;
        private Button SetItemForRoom;
    }
}