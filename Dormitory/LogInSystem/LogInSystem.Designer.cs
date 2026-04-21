namespace LogInSystem
{
    partial class LogInSystem
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EnterTheSystem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(117, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(117, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // LoginInput
            // 
            this.LoginInput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginInput.Location = new System.Drawing.Point(192, 115);
            this.LoginInput.Name = "LoginInput";
            this.LoginInput.Size = new System.Drawing.Size(124, 29);
            this.LoginInput.TabIndex = 2;
            // 
            // PasswordInput
            // 
            this.PasswordInput.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordInput.Location = new System.Drawing.Point(192, 160);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.PasswordChar = '*';
            this.PasswordInput.Size = new System.Drawing.Size(124, 29);
            this.PasswordInput.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(117, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Вход в систему общежития";
            // 
            // EnterTheSystem
            // 
            this.EnterTheSystem.BackColor = System.Drawing.Color.Silver;
            this.EnterTheSystem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterTheSystem.Location = new System.Drawing.Point(121, 207);
            this.EnterTheSystem.Name = "EnterTheSystem";
            this.EnterTheSystem.Size = new System.Drawing.Size(195, 34);
            this.EnterTheSystem.TabIndex = 5;
            this.EnterTheSystem.Text = "Войти";
            this.EnterTheSystem.UseVisualStyleBackColor = false;
            this.EnterTheSystem.Click += new System.EventHandler(this.EnterTheSystem_Click);
            // 
            // LogInSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(444, 311);
            this.Controls.Add(this.EnterTheSystem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.LoginInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LogInSystem";
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LoginInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EnterTheSystem;
    }
}

