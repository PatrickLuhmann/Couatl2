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
	public partial class MainGui : Form
	{
		Couatl2App AppObj;

		public MainGui(Couatl2App NewAppObj)
		{
			AppObj = NewAppObj;

			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// The app is designed to save changes immediately so there
			// is no need for an explicit close here.
			Application.Exit();
		}

		/// <summary>
		/// Allow the user to select a data file.
		/// If the file is valid, update the app data and
		/// switch to the Summary tab.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("File -> Open");

			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.InitialDirectory = "c:\\";
			fileDialog.Filter = "XML files|*.xml";

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				System.Diagnostics.Debug.WriteLine("The user selected the file " + fileDialog.FileName);

				if (AppObj.OpenDbFile(fileDialog.FileName))
				{
					UpdateSummaryTab();
					UpdateAccountTab(false);
				}
			}
		}

		/// <summary>
		/// Update and possibly switch to the Summary tab.
		/// </summary>
		private void UpdateSummaryTab(bool setSelected = true)
		{
			// Update the account list.
			dataGridViewAccountList.DataSource = AppObj.GetAccountListTable();

			// Update the performance chart

			// Update the account value list

			if (setSelected)
				MainTabControl.SelectedTab = SummaryTab;
		}

		private void UpdateAccountTab(bool setSelected = true)
		{
			// Update the account combobox
			AccountComboBox.Items.Clear();
			List<string> acctList = AppObj.GetAccountNameList();
			AccountComboBox.Items.AddRange(acctList.ToArray());
			// TODO: Set an index? If an item had been selected, even from a different
			// file, it will still show up here even though that item is not in the new list.
			
			// Update the positions view

			if (setSelected)
				MainTabControl.SelectedTab = AccountTab;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("File -> New");

			SaveFileDialog fileDialog = new SaveFileDialog();
			fileDialog.InitialDirectory = "c:\\";
			fileDialog.Filter = "XML files|*.xml";
			fileDialog.OverwritePrompt = true;

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				System.Diagnostics.Debug.WriteLine("The user selected the file " + fileDialog.FileName);

				AppObj.CreateNewDbFile(fileDialog.FileName);

				UpdateSummaryTab();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// Create, populate, and show a PurchaseTransactionDialog.
			PurchaseTransactionDialog dlg = new PurchaseTransactionDialog();
			List<string> accts = AppObj.GetAccountNameList();
			foreach (string name in accts)
				dlg.AddAccountName(name);
			dlg.SetAccount(AccountComboBox.SelectedItem.ToString());

			do
			{
				DialogResult result = dlg.ShowDialog();

				if (result == DialogResult.OK)
				{
					System.Diagnostics.Debug.WriteLine("Purchase Transaction Dialog :: Save");
					System.Diagnostics.Debug.WriteLine("Account: " + dlg.GetAccountName());
					System.Diagnostics.Debug.WriteLine("Symbol: " + dlg.GetSymbol());
					System.Diagnostics.Debug.WriteLine("Quantity: " + dlg.GetQuantity());
					System.Diagnostics.Debug.WriteLine("Cost: " + dlg.GetCost());
					System.Diagnostics.Debug.WriteLine("Date: " + dlg.GetDate());

					decimal quantity, cost, commission;

					// Validate the types of the values that the user provided. 
					try
					{
						quantity = Convert.ToDecimal(dlg.GetQuantity());
					}
					catch
					{
						MessageBox.Show("ERROR: Quantity must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						continue;
					}
					try
					{
						cost = Convert.ToDecimal(dlg.GetCost());
					}
					catch
					{
						MessageBox.Show("ERROR: Total Cost must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						continue;
					}
					try
					{
						commission = Convert.ToDecimal(dlg.GetCommission());
					}
					catch
					{
						MessageBox.Show("ERROR: Commission must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						continue;
					}

					DateTime date = dlg.GetDate();

					string account = dlg.GetAccountName();

					string symbol = dlg.GetSymbol().ToUpper();
					// TODO: Symbol needs to already exist in the Symbols table. If it doesn't, need to ask
					// the user for the info. That means popping up another dialog. While this is doable,
					// it seems like a hassle for the user. Would it be possible to save this for later?
					// Add a Name field to the purchase dialog so that the user can do it at the same time?
					// The error message would say "unknown symbol, please add name" and that wouldn't be too
					// bad would it?
					if (!AppObj.FindSymbol(symbol))
					{
						string symName = dlg.GetSymbolName();
						if (symName == "")
						{
							MessageBox.Show("ERROR: Symbol not recognized. Please specify the name of the security.");
							continue;
						}
						if (!AppObj.AddNewSecurity(symbol, symName))
						{
							MessageBox.Show("ERROR adding new symbol. Try again.");
							continue;
						}
					}

					// Create a new entry in the Transactions table.
					if (AppObj.ProcessPurchaseTransaction(account, symbol, quantity, cost, commission, date))
						break;

					MessageBox.Show("ERROR: Could not process transaction. Please check for errors in the input data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
					break;

			} while (true);

		}

		private void createAccountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Pop up a dialog to ask the user for the name to give the account and the 
			// name of the financial institution that holds the account.
			CreateAccountDialog dlg = new CreateAccountDialog();
			do
			{
				DialogResult result = dlg.ShowDialog();

				if (result == DialogResult.OK)
				{
					string acct = dlg.GetAccountName();
					string inst = dlg.GetInstitutionName();

					System.Diagnostics.Debug.WriteLine("Create Account Dialog :: Create");
					System.Diagnostics.Debug.WriteLine("Account Name: " + acct);
					System.Diagnostics.Debug.WriteLine("Institution Name: " + inst);

					AppObj.CreateAccount(acct, inst);

					//pjl test code
					UpdateAccountTab(false);
					UpdateSummaryTab(false);

					//MainTabControl.Refresh();
				}

			} while (false);
		}
	}
}
