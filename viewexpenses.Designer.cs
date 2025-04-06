using System;
using System.Drawing;
using System.Windows.Forms;

namespace PennyWise3
{
    public partial class viewexpenses : Form
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;

        public viewexpenses()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewexpenses));
            this.dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();

            // Suspend layout to prevent flickering during setup
            this.SuspendLayout();

            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new Point(100, 100); // Adjust location as needed
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new Size(800, 400); // Adjust size as needed
            this.dataGridView1.TabIndex = 0;

            // 
            // viewexpenses
            // 
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            this.ClientSize = new Size(1024, 768);
            this.Controls.Add(this.dataGridView1);
            this.Name = "viewexpenses";
            this.Text = "View Expenses";

            // End of DataGridView setup
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();

            // Resume layout after all controls are added
            this.ResumeLayout(false);
        }

        #endregion
    }
}
