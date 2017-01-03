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
			return SymbolTextBox.Text;
		}

		public string GetSymbolName()
		{
			return SymbolNameTextBox.Text;
		}

		public string GetQuantity()
		{
			return QuantityTextBox.Text;
		}

		public string GetCost()
		{
			return CostTextBox.Text;
		}

		public string GetCommission()
		{
			return CommissionTextBox.Text;
		}

		public DateTime GetDate()
		{
			return DatePicker.Value;
		}

		private void SymbolTextBox_Leave(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("PTD :: Leave symbol text box event.");
		}
	}
}
