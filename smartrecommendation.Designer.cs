namespace PennyWise3
{
    partial class smartrecommendation
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
            textBox3 = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Thistle;
            textBox3.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.Black;
            textBox3.Location = new Point(327, 161);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(667, 576);
            textBox3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(1136, 708);
            label2.Name = "label2";
            label2.Size = new Size(156, 29);
            label2.TabIndex = 4;
            label2.Text = "MAIN MENU";
            label2.Click += label2_Click_1;
            // 
            // smartrecommendation
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resource1._71;
            ClientSize = new Size(1378, 782);
            Controls.Add(label2);
            Controls.Add(textBox3);
            Name = "smartrecommendation";
            Text = "Smart Recommendation";
            Load += smartrecommendation_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Label label2;
    }
}