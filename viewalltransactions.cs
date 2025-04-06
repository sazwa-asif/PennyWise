using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;
namespace PennyWise3
{
    public partial class viewalltransactions : Form
    {
        private string _loggedInUsername;

        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb";

        public viewalltransactions(string loggedInUsername)
        {
            InitializeComponent();
            dataGridView1.EnableHeadersVisualStyles = false;
         
            _loggedInUsername = loggedInUsername;

        }



        private void viewalltransactions_Load(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void LoadTransactions()
        {


            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {


                try
                {


                    connection.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT amount, category, Tdate FROM [transaction] WHERE username = @username", connection))

                    {
                        command.Parameters.AddWithValue("@username", _loggedInUsername);
                        OleDbDataAdapter da = new OleDbDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.Columns.Clear();
                        dataGridView1.DataSource = dt;
                    }
                    connection.Close();


                }
                catch (Exception ex)
                {

                }
            }

        }

        private void viewalltransactions_Load_1(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(_loggedInUsername);
            form2.Show(); 
            this.Hide();
        }
    }



}

