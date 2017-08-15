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

		private void UpdateAccountTransactionsView()
		{
			AccountTransactionsView.DataSource = AppObj.GetAccountTransactionTable(AccountComboBox.SelectedItem.ToString());
		}

		private void UpdateAccountPositionsView()
		{
				AccountPositionsView.DataSource = AppObj.GetAccountPositionTable(AccountComboBox.SelectedItem.ToString());
		}

		private void AccountComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("AccountComboBox :: SelectedIndexChanged event handler.");
			System.Diagnostics.Debug.WriteLine("AccountComboBox :: SelectedIndex = " + AccountComboBox.SelectedIndex.ToString() + ".");
			System.Diagnostics.Debug.WriteLine("AccountComboBox :: SelectedItem = " + AccountComboBox.SelectedItem + ".");

			UpdateAccountPositionsView();
			UpdateAccountTransactionsView();
		}

		private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("MainTabControl :: Selecting event handler.");
			System.Diagnostics.Debug.WriteLine("MainTabControl :: Page = " + e.TabPage + ".");
			System.Diagnostics.Debug.WriteLine("MainTabControl :: TabPageIndex = " + e.TabPageIndex + ".");
			System.Diagnostics.Debug.WriteLine("MainTabControl :: Action = " + e.Action + ".");
			System.Diagnostics.Debug.WriteLine("MainTabControl :: Cancel = " + e.Cancel + ".");
			if (e.TabPageIndex == 1)
			{
				System.Diagnostics.Debug.WriteLine("MainTabControl :: Account combo index = " + AccountComboBox.SelectedIndex + ".");
				System.Diagnostics.Debug.WriteLine("MainTabControl :: Account combo qty = " + AccountComboBox.Items.Count + ".");

				if (AccountComboBox.SelectedIndex == -1 && AccountComboBox.Items.Count > 0)
					AccountComboBox.SelectedIndex = 0;
			}
		}

		private void depositCashToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// If there is no account in which to deposit the cash, don't show
			// the dialog box.
			List<string> accts = AppObj.GetAccountNameList();
			if (accts.Count == 0)
			{
				System.Diagnostics.Debug.WriteLine("Deposit Cash Transaction Dialog :: No accounts.");
				MessageBox.Show("ERROR: There are no accounts. Please add an account or open a file that contains an account.", "No Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Create, populate, and show a DepositCashDialog.
			DepositCashDialog dlg = new DepositCashDialog();
			foreach (string name in accts)
				dlg.AddAccountName(name);
			dlg.SetAccount(AccountComboBox.SelectedItem);

			do
			{
				DialogResult result = dlg.ShowDialog();

				if (result == DialogResult.OK)
				{
					System.Diagnostics.Debug.WriteLine("Deposit Cash Transaction Dialog :: Save");
					System.Diagnostics.Debug.WriteLine("Account: " + dlg.GetAccountName());
					System.Diagnostics.Debug.WriteLine("Quantity: " + dlg.GetQuantity());
					System.Diagnostics.Debug.WriteLine("Date: " + dlg.GetDate());

					decimal quantity;

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

					DateTime date = dlg.GetDate();

					string account = dlg.GetAccountName();

					// Update the database with the details of this deposit.
					if (AppObj.ProcessDepositCashTransaction(account, quantity, date))
					{
						// Update Account tab (transaction view only, does not change positions)
						// TODO: If Cash becomes a position then do more here.
						UpdateAccountTransactionsView();

						break;
					}

					MessageBox.Show("ERROR: Could not process deposit cash transaction. Please check for errors in the input data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
					break;

			} while (true);
		}

		private void recordCashDividendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// If there is no account in which to deposit the cash, don't show
			// the dialog box.
			List<string> accts = AppObj.GetAccountNameList();
			if (accts.Count == 0)
			{
				System.Diagnostics.Debug.WriteLine("Record Cash Dividend Transaction Dialog :: No accounts.");
				MessageBox.Show("ERROR: There are no accounts. Please add an account or open a file that contains an account.", "No Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Create, populate, and show a RecordCashDividendDialog.
			RecordCashDividendDialog dlg = new RecordCashDividendDialog();
			foreach (string name in accts)
				dlg.AddAccountName(name);
			dlg.SetAccount(AccountComboBox.SelectedItem);

			do
			{
				DialogResult result = dlg.ShowDialog();

				if (result == DialogResult.OK)
				{
					System.Diagnostics.Debug.WriteLine("Record Cash Dividend Transaction Dialog :: Save");
					System.Diagnostics.Debug.WriteLine("Account: " + dlg.GetAccountName());
					System.Diagnostics.Debug.WriteLine("Security: " + dlg.GetSecurity());
					System.Diagnostics.Debug.WriteLine("Value: " + dlg.GetValue());
					System.Diagnostics.Debug.WriteLine("Date: " + dlg.GetDate());

					string security = dlg.GetSecurity();

					decimal value;

					// Validate the types of the values that the user provided. 
					try
					{
						value = Convert.ToDecimal(dlg.GetValue());
					}
					catch
					{
						MessageBox.Show("ERROR: Value must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						continue;
					}

					DateTime date = dlg.GetDate();

					string account = dlg.GetAccountName();

					// Update the database with the details of this deposit.
					if (AppObj.ProcessRecordCashDividendTransaction(account, security, value, date))
					{
						// Update Account tab (transaction view only, does not change positions)
						// TODO: If Cash becomes a position then do more here.
						UpdateAccountTransactionsView();

						break;
					}

					MessageBox.Show("ERROR: Could not process record cash dividend transaction. Please check for errors in the input data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
					break;

			} while (true);

		}

		private void buySecurityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// If there is no account in which to record the transaction,
			// don't show the dialog box.
			List<string> accts = AppObj.GetAccountNameList();
			if (accts.Count == 0)
			{
				System.Diagnostics.Debug.WriteLine("Buy Security Transaction Dialog :: No accounts.");
				MessageBox.Show("ERROR: There are no accounts. Please add an account or open a file that contains an account.", "No Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Create, populate, and show a PurchaseTransactionDialog.
			PurchaseTransactionDialog dlg = new PurchaseTransactionDialog();
			foreach (string name in accts)
				dlg.AddAccountName(name);
			dlg.SetAccount(AccountComboBox.SelectedItem);

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

					// Update the database with the details of this purchase.
					if (AppObj.ProcessPurchaseTransaction(account, symbol, quantity, cost, commission, date))
					{
						// update Account tab
						UpdateAccountTransactionsView();
						UpdateAccountPositionsView();

						break;
					}

					MessageBox.Show("ERROR: Could not process transaction. Please check for errors in the input data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
					break;

			} while (true);
		}

		private void sellSecurityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// If there is no account in which to record the transaction,
			// don't show the dialog box.
			List<string> accts = AppObj.GetAccountNameList();
			if (accts.Count == 0)
			{
				System.Diagnostics.Debug.WriteLine("Sell Security Transaction Dialog :: No accounts.");
				MessageBox.Show("ERROR: There are no accounts. Please add an account or open a file that contains an account.", "No Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Create, populate, and show a SellTransactionDialog.
			SellTransactionDialog dlg = new SellTransactionDialog();
			foreach (string name in accts)
				dlg.AddAccountName(name);
			dlg.SetAccount(AccountComboBox.SelectedItem);

			do
			{
				DialogResult result = dlg.ShowDialog();

				if (result == DialogResult.OK)
				{
					System.Diagnostics.Debug.WriteLine("Sell Transaction Dialog :: Save");
					System.Diagnostics.Debug.WriteLine("Account: " + dlg.GetAccountName());
					System.Diagnostics.Debug.WriteLine("Symbol: " + dlg.GetSymbol());
					System.Diagnostics.Debug.WriteLine("Quantity: " + dlg.GetQuantity());
					System.Diagnostics.Debug.WriteLine("Proceeds: " + dlg.GetProceeds());
					System.Diagnostics.Debug.WriteLine("Date: " + dlg.GetDate());

					decimal quantity, proceeds, commission;

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
						proceeds = Convert.ToDecimal(dlg.GetProceeds());
					}
					catch
					{
						MessageBox.Show("ERROR: Total Proceeds must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

					// Update the database with the details of this sale.
					if (AppObj.ProcessSellTransaction(account, symbol, quantity, proceeds, commission, date))
					{
						// update Account tab
						UpdateAccountTransactionsView();
						UpdateAccountPositionsView();

						break;
					}

					MessageBox.Show("ERROR: Could not process transaction. Please check for errors in the input data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
					break;

			} while (true);
		}
	}
}
