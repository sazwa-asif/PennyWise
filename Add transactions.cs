using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PennyWise3
{
    public partial class Add_transactions : Form
    {
        private string _loggedInUsername { get; set; }


        private LinkedList<Transaction> transactionList = new LinkedList<Transaction>();

        public class Transaction
        {
            public decimal Amount { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string Username { get; set; }
        }

        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        public class LinkedList<T> : IEnumerable<T>
        {
            private Node<T> head;
            private Node<T> tail;

            public LinkedList()
            {
                head = null;
                tail = null;
            }

            public void AddLast(T data)
            {
                Node<T> newNode = new Node<T>(data);
                if (head == null)
                {
                    head = tail = newNode;
                }
                else
                {
                    tail.Next = newNode;
                    tail = newNode;
                }
            }

            public Node<T> GetHead() => head;

            public void Clear()
            {
                head = tail = null;
            }

          
            public IEnumerator<T> GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


        public Add_transactions(string loggedInUsername)
        {
            InitializeComponent();
            _loggedInUsername = loggedInUsername;
        }


        private void Add_transactions_Load(object sender, EventArgs e)
        {
            label2.Click += label2_Click;
        }


        private void label1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(_loggedInUsername);
            f.Show();
            this.Hide();
        }


        private void label2_Click(object sender, EventArgs e)
        {
            this.label2.Visible = true;
            this.label2.Enabled = true;
            this.label2.Cursor = Cursors.Hand;

            try
            {
                decimal amount = decimal.Parse(textBox1.Text);
                string category = comboBox1.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(category))
                {
                    MessageBox.Show("Please select a category!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime date = dateTimePicker1.Value;

              
                Transaction newTransaction = new Transaction
                {
                    Amount = amount,
                    Category = category,
                    Date = date,
                    Username = _loggedInUsername
                };
                transactionList.AddLast(newTransaction);

                MessageBox.Show("Transaction added to the list!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

         
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTransactionsToDatabase()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (OleDbTransaction dbTransaction = connection.BeginTransaction())
                    {
                        foreach (var transaction in transactionList)
                        {
                            string query = "INSERT INTO [transaction] (amount, category, Tdate, username) VALUES (?, ?, ?, ?)";
                            using (OleDbCommand cmd = new OleDbCommand(query, connection, dbTransaction))
                            {
                                cmd.Parameters.Add("?", OleDbType.Currency).Value = transaction.Amount;
                                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = transaction.Category;
                                cmd.Parameters.Add("?", OleDbType.Date).Value = transaction.Date;
                                cmd.Parameters.Add("?", OleDbType.VarWChar).Value = transaction.Username;

                                cmd.ExecuteNonQuery();
                            }
                        }

                        dbTransaction.Commit(); 
                    }

                    transactionList.Clear();
                    MessageBox.Show("All transactions saved to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving transactions: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Add_transactions_Load_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (transactionList.GetHead() == null)
            {
                MessageBox.Show("No transactions to save!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveTransactionsToDatabase();

        }
    }
}
