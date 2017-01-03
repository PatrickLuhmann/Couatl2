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

		public void SetAccount(string name)
		{
			if (comboBox1.Items.Contains(name))
				comboBox1.SelectedIndex = comboBox1.Items.IndexOf(name);
			else if (comboBox1.SelectedIndex == -1)
				// This feels sloppy but the alternative is too complex for what is really needed.
				comboBox1.SelectedIndex = 0;
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
			// The order of events is
			// 1. LostFocus - I think MSDN says not to use this for normal stuff.
			// 2. Leave
			// 3. Validating
			// 4. Validated
			System.Diagnostics.Debug.WriteLine("PTD :: Leave symbol text box event.");
		}

		private void SymbolTextBox_Validating(object sender, CancelEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Validating symbol " + SymbolTextBox.Text);
			errorProvider1.SetIconAlignment(SymbolTextBox, ErrorIconAlignment.MiddleLeft);
			errorProvider1.SetIconPadding(SymbolTextBox, 2);
			if (!System.Text.RegularExpressions.Regex.IsMatch(SymbolTextBox.Text, @"^[A-Z]{1,5}$"))
			{
				errorProvider1.SetError(SymbolTextBox, "Symbol must be less than six upper-case letters.");
			}
			else
			{
				errorProvider1.SetError(SymbolTextBox, string.Empty);
			}
		}
	}
}
