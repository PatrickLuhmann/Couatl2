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
	public partial class RecordCashDividendDialog : Form
	{
		public RecordCashDividendDialog()
		{
			InitializeComponent();
		}
		public void AddAccountName(string name)
		{
			comboBoxAccount.Items.Add(name);
		}

		public void SetAccount(object name)
		{
			if (name != null)
			{
				if (comboBoxAccount.Items.Contains(name))
					comboBoxAccount.SelectedIndex = comboBoxAccount.Items.IndexOf(name);
				else if (comboBoxAccount.SelectedIndex == -1)
					// This feels sloppy but the alternative is too complex for what is really needed.
					comboBoxAccount.SelectedIndex = 0;
			}
			else
				comboBoxAccount.SelectedIndex = 0;
		}

		public string GetAccountName()
		{
			return comboBoxAccount.Items[comboBoxAccount.SelectedIndex].ToString();
		}

		public string GetSecurity()
		{
			return textBoxSecurity.Text;
		}
		public string GetValue()
		{
			return textBoxValue.Text;
		}

		public DateTime GetDate()
		{
			return dateTimePickerDate.Value;
		}
	}
}
