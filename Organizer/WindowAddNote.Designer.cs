namespace Organizer
{
    partial class WindowAddNote
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxMainInf = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(184, 43);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(228, 26);
            this.textBoxName.TabIndex = 0;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Items.AddRange(new object[] {
            "First",
            "High",
            "Mid",
            "Low"});
            this.comboBoxPriority.Location = new System.Drawing.Point(184, 123);
            this.comboBoxPriority.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(180, 28);
            this.comboBoxPriority.TabIndex = 1;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(108, 418);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(112, 35);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(500, 417);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 35);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cansel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxMainInf
            // 
            this.textBoxMainInf.Location = new System.Drawing.Point(52, 238);
            this.textBoxMainInf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxMainInf.Multiline = true;
            this.textBoxMainInf.Name = "textBoxMainInf";
            this.textBoxMainInf.Size = new System.Drawing.Size(598, 115);
            this.textBoxMainInf.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(478, 121);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // WindowAddNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 494);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBoxMainInf);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.textBoxName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WindowAddNote";
            this.Text = "WindowAddNote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxMainInf;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}