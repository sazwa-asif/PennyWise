using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PennyWise3
{
    public partial class ViewExpenses : Form
    {
        private string _loggedInUsername;
     
        private DataGridView dataGridView1;


        public ViewExpenses(string loggedInUsername)
        {
            InitializeComponent();
            _loggedInUsername = loggedInUsername;
            //LoadExpenses();
        }

        private void LoadExpenses()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb";
            //string query = "SELECT category, SUM(amount) AS TotalAmount FROM [transaction] WHERE username = ? GROUP BY category";
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT category, SUM(amount) AS TotalAmount FROM[transaction] WHERE username = @username GROUP BY category", connection))

                {
                    command.Parameters.AddWithValue("@username", _loggedInUsername);
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = dt;
                }
                connection.Close();

                //using (OleDbConnection connection = new OleDbConnection(connectionString))
                //{
                //    Console.WriteLine("Connecting to database with connection string: " + connectionString);
                //    Console.WriteLine("SQL Query: " + query);

                //    connection.Open();

                //    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                //    {

                //        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = _loggedInUsername;


                //        Console.WriteLine("Using parameter username: " + _loggedInUsername);

                //        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                // OleDbDataAdapter da = new OleDbDataAdapter(command);
                //DataTable dt = new DataTable();
                //adapter.Fill(dt);
                // dataGridView2.Columns.Clear();
                // dataGridView2.DataSource = dt;
                //onnection.Close();
                //{
                //    DataTable dataTable = new DataTable();
                //    adapter.Fill(dataTable);


                //    Console.WriteLine("Fetched " + dataTable.Rows.Count + " rows.");


                //    dataGridView1.DataSource = dataTable;
                //}
                //}
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error loading expenses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewExpenses_Load(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        private void InitializeComponent()
        {
            MessageBox.Show("Logged In Username: " + _loggedInUsername);
            dataGridView2 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dataGridView2.Location = new Point(423, 92);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(367, 413);
            dataGridView2.TabIndex = 0;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Category";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Total Amount";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 150;
            // 
            // ViewExpenses
            // 
            ClientSize = new Size(1137, 587);
            Controls.Add(dataGridView2);
            Name = "ViewExpenses";
            Load += ViewExpenses_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        private void ViewExpenses_Load_1(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
