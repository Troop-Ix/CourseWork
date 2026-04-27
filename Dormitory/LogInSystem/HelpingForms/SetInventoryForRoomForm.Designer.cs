namespace LogInSystem.HelpingForms
{
    partial class SetInventoryForRoomForm
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
            this.NumbersList = new System.Windows.Forms.ComboBox();
            this.FloorsList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Set = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumbersList
            // 
            this.NumbersList.FormattingEnabled = true;
            this.NumbersList.Location = new System.Drawing.Point(442, 61);
            this.NumbersList.Name = "NumbersList";
            this.NumbersList.Size = new System.Drawing.Size(121, 21);
            this.NumbersList.TabIndex = 0;
            // 
            // FloorsList
            // 
            this.FloorsList.FormattingEnabled = true;
            this.FloorsList.Location = new System.Drawing.Point(152, 61);
            this.FloorsList.Name = "FloorsList";
            this.FloorsList.Size = new System.Drawing.Size(121, 21);
            this.FloorsList.TabIndex = 1;
            this.FloorsList.SelectedIndexChanged += new System.EventHandler(this.FloorsList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите этаж";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(292, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите номер";
            // 
            // Set
            // 
            this.Set.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Set.Location = new System.Drawing.Point(228, 115);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(114, 36);
            this.Set.TabIndex = 4;
            this.Set.Text = "Установить";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // SetInventoryForRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 172);
            this.Controls.Add(this.Set);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FloorsList);
            this.Controls.Add(this.NumbersList);
            this.Name = "SetInventoryForRoomForm";
            this.Text = "SetInventoryForRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox NumbersList;
        private System.Windows.Forms.ComboBox FloorsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Set;
    }
}