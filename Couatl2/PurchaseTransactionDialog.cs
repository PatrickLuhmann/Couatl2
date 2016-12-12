using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Couatl2
{
	public partial class PurchaseTransactionDialog : Form
	{
		public PurchaseTransactionDialog()
		{
			InitializeComponent();
		}

		private void label1_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("PTD :: Save button");

		}

		private void button2_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("PTD :: Cancel button");
		}

		public void AddAccountName(string name)
		{
			comboBox1.Items.Add(name);
		}

		public string GetAccountName()
		{
			return comboBox1.Items[comboBox1.SelectedIndex].ToString();
		}

		public string GetSymbol()
		{
			return textBox1.Text;
		}

		public string GetQuantity()
		{
			return textBox2.Text;
		}

		public string GetCost()
		{
			return textBox3.Text;
		}

		public DateTime GetDate()
		{
			return dateTimePicker1.Value;
		}
	}
}
