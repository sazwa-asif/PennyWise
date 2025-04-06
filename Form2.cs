using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PennyWise3
{
    public partial class Form2 : Form
    {

        public string LoggedInUsername { get; set; }


        public Form2(string loggedInUSername)
        {
            InitializeComponent();
            LoggedInUsername = loggedInUSername;
            label5.Text = "Get Smart Spending\nRecommendation";
            label6.Text = "View Total Expenses\nby Category";
        }
        public Form2()
        {
            InitializeComponent();
            LoggedInUsername = "Guest";
        }

        private void label1_Click(object sender, EventArgs e)
        {

            Form addTransactionForm = new Add_transactions(LoggedInUsername);
            addTransactionForm.Show();
            this.Hide();


        }

        private void label5_Click(object sender, EventArgs e)
        {
            smartrecommendation s = new smartrecommendation(LoggedInUsername);
            s.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            expense_category v = new expense_category(LoggedInUsername);
            v.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            viewalltransactions viewTransactionsForm = new viewalltransactions(LoggedInUsername);
            viewTransactionsForm.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}