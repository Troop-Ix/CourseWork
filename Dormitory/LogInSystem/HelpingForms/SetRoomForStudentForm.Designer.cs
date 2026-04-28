namespace LogInSystem.HelpingForms
{
    partial class SetRoomForStudentForm
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
            this.Set = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Set
            // 
            this.Set.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Set.Location = new System.Drawing.Point(241, 124);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(114, 36);
            this.Set.TabIndex = 4;
            this.Set.Text = "Установить";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 109);
            this.panel1.TabIndex = 5;
            // 
            // SetRoomForStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 172);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Set);
            this.Name = "SetRoomForStudentForm";
            this.Text = "Заселение студента";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Set;
        private System.Windows.Forms.Panel panel1;

    }
}