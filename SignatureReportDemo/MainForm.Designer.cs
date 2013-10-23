namespace SignatureReportExample
{
    partial class MainForm
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
            this.locations_combo = new System.Windows.Forms.ComboBox();
            this.programs_combo = new System.Windows.Forms.ComboBox();
            this.start_date_picker = new System.Windows.Forms.DateTimePicker();
            this.end_date_picker = new System.Windows.Forms.DateTimePicker();
            this.Location = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.result_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // locations_combo
            // 
            this.locations_combo.FormattingEnabled = true;
            this.locations_combo.Location = new System.Drawing.Point(69, 6);
            this.locations_combo.Name = "locations_combo";
            this.locations_combo.Size = new System.Drawing.Size(476, 21);
            this.locations_combo.TabIndex = 0;
            this.locations_combo.SelectedIndexChanged += new System.EventHandler(this.locations_combo_SelectedIndexChanged);
            // 
            // programs_combo
            // 
            this.programs_combo.FormattingEnabled = true;
            this.programs_combo.Location = new System.Drawing.Point(69, 33);
            this.programs_combo.Name = "programs_combo";
            this.programs_combo.Size = new System.Drawing.Size(476, 21);
            this.programs_combo.TabIndex = 1;
            this.programs_combo.SelectedIndexChanged += new System.EventHandler(this.programs_combo_SelectedIndexChanged);
            // 
            // start_date_picker
            // 
            this.start_date_picker.CustomFormat = "";
            this.start_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.start_date_picker.Location = new System.Drawing.Point(130, 59);
            this.start_date_picker.Name = "start_date_picker";
            this.start_date_picker.Size = new System.Drawing.Size(100, 20);
            this.start_date_picker.TabIndex = 2;
            // 
            // end_date_picker
            // 
            this.end_date_picker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.end_date_picker.Location = new System.Drawing.Point(325, 60);
            this.end_date_picker.Name = "end_date_picker";
            this.end_date_picker.Size = new System.Drawing.Size(100, 20);
            this.end_date_picker.TabIndex = 3;
            // 
            // Location
            // 
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(12, 9);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(51, 13);
            this.Location.TabIndex = 4;
            this.Location.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Program:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "End Date:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(469, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Run Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // result_label
            // 
            this.result_label.AutoSize = true;
            this.result_label.Location = new System.Drawing.Point(12, 85);
            this.result_label.Name = "result_label";
            this.result_label.Size = new System.Drawing.Size(35, 13);
            this.result_label.TabIndex = 9;
            this.result_label.Text = "label4";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 107);
            this.Controls.Add(this.result_label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.end_date_picker);
            this.Controls.Add(this.start_date_picker);
            this.Controls.Add(this.programs_combo);
            this.Controls.Add(this.locations_combo);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox locations_combo;
        private System.Windows.Forms.ComboBox programs_combo;
        private System.Windows.Forms.DateTimePicker start_date_picker;
        private System.Windows.Forms.DateTimePicker end_date_picker;
        private System.Windows.Forms.Label Location;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label result_label;

    }
}

