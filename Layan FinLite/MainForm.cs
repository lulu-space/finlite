using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Layan_FinLite
{
    public partial class MainForm : Form
    {
        private List<Transaction> transactions = new List<Transaction>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "Food", "Salary", "Rent", "Utilities" });
            toolTip1.SetToolTip(button1, "Click to add transaction");

        }

        private void UpdateDashboard()
        {
            decimal income = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal expense = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            decimal savings = income - expense;

            label1.Text = $"Income: {income:C}";
            label2.Text = $"Expenses: {expense:C}";
            label3.Text = $"Savings: {savings:C}";
        }

        private void UpdateReports()
        {
            listView1.Items.Clear();

            foreach (var t in transactions)
            {
                ListViewItem item = new ListViewItem(t.Date.ToShortDateString());
                item.SubItems.Add(t.Description);
                item.SubItems.Add(t.Category);
                item.SubItems.Add(t.Amount.ToString("C"));
                item.SubItems.Add(t.Type);

                listView1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || comboBox1.SelectedIndex == -1)
                    throw new Exception("All fields are required.");

                decimal amount = numericUpDown1.Value;
                if (amount <= 0)
                    throw new Exception("Amount must be more than 0.");

                string type = radioButton1.Checked ? "Income" : "Expense";

                Transaction transaction = type == "Income"
                    ? new Income()
                    : (Transaction)new Expense();

                transaction.Description = textBox1.Text;
                transaction.Amount = amount;
                transaction.Category = comboBox1.Text;
                transaction.Date = dateTimePicker1.Value;
                transaction.Type = type;

                transactions.Add(transaction);

                MessageBox.Show("Transaction added successfully!");

                UpdateDashboard();
                UpdateReports();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.investopedia.com",
                UseShellExecute = true
            });
        }

        private void ExportReport()
        {
            if (transactions.Count == 0)
            {
                MessageBox.Show("No transactions to export.", "Export Report");
                return;
            }

            var report = string.Join("\n", transactions.Select(t =>
                $"{t.Date.ToShortDateString()} - {t.Description} - {t.Category} - {t.Amount:C} - {t.Type}"));

            MessageBox.Show(report, "Transaction Report");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportReport();
        }
    }
}
