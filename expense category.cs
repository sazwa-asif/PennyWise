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
    public partial class expense_category : Form
    {
        private string _loggedInUsername;

        public class HashMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
        {
            private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
            private int size;

            public HashMap(int size = 16)
            {
                this.size = size;
                buckets = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            }

           
            private int GetBucketIndex(TKey key)
            {
                return Math.Abs(key.GetHashCode()) % size;
            }

            
            public void Add(TKey key, TValue value)
            {
                int index = GetBucketIndex(key);
                if (buckets[index] == null)
                {
                    buckets[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                }

           
                foreach (var kvp in buckets[index])
                {
                    if (kvp.Key.Equals(key))
                    {
                      
                        var node = buckets[index].Find(kvp);
                        node.Value = new KeyValuePair<TKey, TValue>(key, value);
                        return;
                    }
                }

           
                buckets[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }

       
            public TValue Get(TKey key)
            {
                int index = GetBucketIndex(key);
                if (buckets[index] != null)
                {
                    foreach (var kvp in buckets[index])
                    {
                        if (kvp.Key.Equals(key))
                        {
                            return kvp.Value;
                        }
                    }
                }

                throw new KeyNotFoundException("Key not found.");
            }

         
            public bool ContainsKey(TKey key)
            {
                int index = GetBucketIndex(key);
                if (buckets[index] != null)
                {
                    foreach (var kvp in buckets[index])
                    {
                        if (kvp.Key.Equals(key))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

      
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                foreach (var bucket in buckets)
                {
                    if (bucket != null)
                    {
                        foreach (var kvp in bucket)
                        {
                            yield return kvp;
                        }
                    }
                }
            }

       
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public expense_category(string loggedInUsername)
        {
            InitializeComponent();
            _loggedInUsername = loggedInUsername;
            dataGridView1.EnableHeadersVisualStyles = false;

        }

        private void expense_category_Load(object sender, EventArgs e)
        {
            LoadExpenses();
        }

        private void LoadExpenses()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Documents\PennyWise.accdb";

            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {

                connection.Open();
                HashMap<string, decimal> categoryTotalMap = new HashMap<string, decimal>();
                using (OleDbCommand command = new OleDbCommand("SELECT category, SUM(amount) AS TotalAmount FROM[transaction] WHERE username = @username GROUP BY category", connection))

                {
                    command.Parameters.AddWithValue("@username", _loggedInUsername);
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);


                    foreach (DataRow row in dt.Rows)
                    {
                        string category = row["category"].ToString();
                        decimal totalAmount = Convert.ToDecimal(row["TotalAmount"]);


                    
                        categoryTotalMap.Add(category, totalAmount);
                    }


                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("Category", typeof(string));
                    displayTable.Columns.Add("TotalAmount", typeof(decimal));


                    foreach (var entry in categoryTotalMap)
                    {
                        displayTable.Rows.Add(entry.Key, entry.Value);
                    }
                    dataGridView1.Columns.Clear();
                    dataGridView1.DataSource = displayTable;
                }
                connection.Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error loading expenses: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(_loggedInUsername);
            f.Show();
            this.Hide();
        }
    }
}
