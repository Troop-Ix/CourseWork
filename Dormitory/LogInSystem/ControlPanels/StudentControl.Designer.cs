using System.Drawing;
using System.Windows.Forms;

namespace LogInSystem
{
    partial class StudentControl
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
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Faculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BenefitIds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnterSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.RoomID,
            this.Surname,
            this.SName,
            this.MiddleName,
            this.BirthDate,
            this.PhoneNumber,
            this.Faculty,
            this.Group,
            this.BenefitIds});
            this.dataGridView1.Location = new System.Drawing.Point(3, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 201);
            this.dataGridView1.TabIndex = 0;
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "ID";
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            // 
            // RoomID
            // 
            this.RoomID.DataPropertyName = "RoomID";
            this.RoomID.HeaderText = "ID комнаты";
            this.RoomID.Name = "RoomID";
            this.RoomID.ReadOnly = true;
            // 
            // Surname
            // 
            this.Surname.DataPropertyName = "Surname";
            this.Surname.HeaderText = "Фамилия";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            // 
            // SName
            // 
            this.SName.DataPropertyName = "Name";
            this.SName.HeaderText = "Имя";
            this.SName.Name = "SName";
            this.SName.ReadOnly = true;
            // 
            // MiddleName
            // 
            this.MiddleName.DataPropertyName = "Middlename";
            this.MiddleName.HeaderText = "Отчество";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.ReadOnly = true;
            // 
            // BirthDate
            // 
            this.BirthDate.DataPropertyName = "Birthdate";
            this.BirthDate.HeaderText = "Дата рождения";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "Телефон";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            // 
            // Faculty
            // 
            this.Faculty.DataPropertyName = "Faculty";
            this.Faculty.HeaderText = "Факультет";
            this.Faculty.Name = "Faculty";
            this.Faculty.ReadOnly = true;
            // 
            // Group
            // 
            this.Group.DataPropertyName = "Group";
            this.Group.HeaderText = "Группа";
            this.Group.Name = "Group";
            this.Group.ReadOnly = true;
            // 
            // BenefitIds
            // 
            this.BenefitIds.DataPropertyName = "BenefitIds";
            this.BenefitIds.HeaderText = "Льготы";
            this.BenefitIds.Name = "BenefitIds";
            this.BenefitIds.ReadOnly = true;
            // 
            // EnterSurname
            // 
            this.EnterSurname.Location = new System.Drawing.Point(549, 120);
            this.EnterSurname.Name = "EnterSurname";
            this.EnterSurname.Size = new System.Drawing.Size(199, 20);
            this.EnterSurname.TabIndex = 1;
            this.EnterSurname.TextChanged += new System.EventHandler(this.EnterSurname_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Введите фамилию для поиска";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(560, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Студенты";
            // 
            // StudentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterSurname);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StudentControl";
            this.Size = new System.Drawing.Size(1064, 584);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox EnterSurname;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn StudentID;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn Surname;
        private DataGridViewTextBoxColumn SName;
        private DataGridViewTextBoxColumn MiddleName;
        private DataGridViewTextBoxColumn BirthDate;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Faculty;
        private DataGridViewTextBoxColumn Group;
        private DataGridViewTextBoxColumn BenefitIds;
    }
}
