using System.Data.OleDb;
namespace PennyWise3
{
    public partial class Form1 : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public string LoggedInUsername { get; private set; }

        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb;Persist Security Info=False;";
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

            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from acount where username = '" + textBox1.Text + "' and password ='" + textBox2.Text + "'";

            OleDbDataReader or = cmd.ExecuteReader();

            int count = 0;
            while (or.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                LoggedInUsername = username;

                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                Form2 f = new Form2(LoggedInUsername);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username and Password does not exist! Please Register", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                signup f3 = new signup();
                f3.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
            signup f3 = new signup();
            f3.Show();
            this.Hide();
        }
    }
}