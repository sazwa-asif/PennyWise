namespace PennyWise3
{
    partial class Add_transactions
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(775, 252);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 31);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(259, 639);
            label1.Name = "label1";
            label1.Size = new Size(156, 29);
            label1.TabIndex = 3;
            label1.Text = "MAIN MENU";
            label1.Click += label1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.CalendarForeColor = Color.DarkSlateBlue;
            dateTimePicker1.CalendarMonthBackground = Color.Thistle;
            dateTimePicker1.CalendarTitleBackColor = Color.Thistle;
            dateTimePicker1.CalendarTitleForeColor = Color.DarkSlateBlue;
            dateTimePicker1.Location = new Point(775, 473);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 31);
            dateTimePicker1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Cursor = Cursors.Hand;
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(653, 639);
            label2.Name = "label2";
            label2.Size = new Size(75, 29);
            label2.TabIndex = 6;
            label2.Text = "SAVE";
            label2.Click += label2_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Housing", "Transportation", "Food", "Utilities", "Medical", "Insurance", "Personal", "Entertainment", "Others" });
            comboBox1.Location = new Point(775, 365);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 33);
            comboBox1.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(996, 636);
            label3.Name = "label3";
            label3.Size = new Size(220, 32);
            label3.TabIndex = 8;
            label3.Text = "SAVE TO DATABASE";
            label3.Click += label3_Click;
            // 
            // Add_transactions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resource1._51;
            ClientSize = new Size(1378, 744);
            Controls.Add(label3);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "Add_transactions";
            Text = "Add Transactions";
            Load += Add_transactions_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox textBox1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private ComboBox comboBox1;
        private Label label3;
    }
}
