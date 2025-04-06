using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PennyWise3
{
    public partial class smartrecommendation : Form
    {
        private string _loggedInUsername;

        public smartrecommendation(string loggedInUsername)
        {
            InitializeComponent();
            _loggedInUsername = loggedInUsername;
            textBox3.Multiline = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
        }
        private void smartrecommendation_Load(object sender, EventArgs e)
        {
            LoadCategories();
            textBox3.SelectionLength = 0;
        }

        private void LoadCategories()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                List<string> categories = new List<string>();

                using (OleDbCommand command = new OleDbCommand("SELECT DISTINCT category FROM [transaction] WHERE username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", _loggedInUsername);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        categories.Add(reader["category"].ToString());
                    }
                }

                ProcessCategories(categories);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ProcessCategories(List<string> categories)
        {
            PriorityQueue categoryHeap = new PriorityQueue();

            foreach (var category in categories)
            {
                decimal totalSpending = GetTotalSpendingForCategory(category);
                categoryHeap.Enqueue(category, -totalSpending); 
            }

            GenerateRecommendations(categoryHeap);
        }



        private decimal GetTotalSpendingForCategory(string category)
        {
            decimal totalSpending = 0;
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb";
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT SUM(amount) FROM [transaction] WHERE category = @category AND username = @username", connection))
                {
                    command.Parameters.AddWithValue("@category", category);
                    command.Parameters.AddWithValue("@username", _loggedInUsername);
                    totalSpending = Convert.ToDecimal(command.ExecuteScalar());
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total spending: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSpending;
        }

        private void GenerateRecommendations(PriorityQueue categoryHeap)
        {
            StringBuilder recommendations = new StringBuilder();
            recommendations.AppendLine("Smart Spending Recommendations based on your spending:" + Environment.NewLine + Environment.NewLine);

            while (categoryHeap.Count > 0)
            {
                var (category, totalSpending) = categoryHeap.Dequeue();
                recommendations.AppendLine($"Category: {category} - Total Spending: ${-totalSpending}");

                if (-totalSpending > 30000)
                {
                    recommendations.AppendLine($"Consider reducing spending in {category}. Look for discounts or alternatives." + Environment.NewLine);
                }
                else if (-totalSpending > 15000)
                {
                    recommendations.AppendLine($"Spending on {category} is moderate. Evaluate if it aligns with your budget." + Environment.NewLine);
                }
                else
                {
                    recommendations.AppendLine($"Good job keeping {category} spending low. Keep it up!" + Environment.NewLine);
                }
            }

            textBox3.Text = recommendations.ToString();
        }



        private void label2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(_loggedInUsername);
            f.Show();
            this.Hide();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2(_loggedInUsername);
            f.Show();
            this.Hide();
        }

        public class PriorityQueue
        {
            private List<(string category, decimal priority)> _heap = new List<(string, decimal)>();

            public int Count => _heap.Count;

            public void Enqueue(string category, decimal priority)
            {
                _heap.Add((category, priority));
                HeapifyUp(_heap.Count - 1);
            }

            public (string category, decimal priority) Dequeue()
            {
                if (_heap.Count == 0) throw new InvalidOperationException("Priority queue is empty.");

                var top = _heap[0];
                _heap[0] = _heap[_heap.Count - 1];
                _heap.RemoveAt(_heap.Count - 1);
                HeapifyDown(0);
                return top;
            }

            private void HeapifyUp(int index)
            {
                while (index > 0)
                {
                    int parentIndex = (index - 1) / 2;
                    if (_heap[index].priority >= _heap[parentIndex].priority) break;

                    Swap(index, parentIndex);
                    index = parentIndex;
                }
            }

            private void HeapifyDown(int index)
            {
                while (true)
                {
                    int left = 2 * index + 1;
                    int right = 2 * index + 2;
                    int smallest = index;

                    if (left < _heap.Count && _heap[left].priority < _heap[smallest].priority)
                    {
                        smallest = left;
                    }
                    if (right < _heap.Count && _heap[right].priority < _heap[smallest].priority)
                    {
                        smallest = right;
                    }
                    if (smallest == index) break;

                    Swap(index, smallest);
                    index = smallest;
                }
            }

            private void Swap(int i, int j)
            {
                var temp = _heap[i];
                _heap[i] = _heap[j];
                _heap[j] = temp;
            }
        }
    }
}
