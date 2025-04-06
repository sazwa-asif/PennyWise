using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PennyWise3
{
    public partial class signup : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public signup()
        {
            InitializeComponent();

            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb;
Persist Security Info=False;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            try
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand("INSERT INTO acount ([username], [password]) VALUES (?, ?)", conn))
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("One record has been inserted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }
    }
}