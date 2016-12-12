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
				}
			}
		}

		/// <summary>
		/// Update and switch to the Summary tab.
		/// </summary>
		private void UpdateSummaryTab()
		{
			dataGridViewAccountList.DataSource = AppObj.GetAccountListTable();
			tabControl1.SelectedTab = tabSummary;
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
			// Bring up a PurchaseTransactionDialog.
			PurchaseTransactionDialog dlg = new PurchaseTransactionDialog();
			// Fill the account combo box with the account names.
			dlg.AddAccountName("Account 1");
			dlg.AddAccountName("Account 2");

			DialogResult result = dlg.ShowDialog();

			// What happens when the dialog is closed?
			if (result == DialogResult.OK)
			{
				System.Diagnostics.Debug.WriteLine("Purchase Transaction Dialog :: Save");
				System.Diagnostics.Debug.WriteLine("Account: " + dlg.GetAccountName());
				System.Diagnostics.Debug.WriteLine("Symbol: " + dlg.GetSymbol());
				System.Diagnostics.Debug.WriteLine("Quantity: " + dlg.GetQuantity());
				System.Diagnostics.Debug.WriteLine("Cost: " + dlg.GetCost());
				System.Diagnostics.Debug.WriteLine("Date: " + dlg.GetDate());

				decimal quantity;
				decimal cost;

				// Validate the types of the values that the user provided. 
				try
				{
					quantity = Convert.ToDecimal(dlg.GetQuantity());
				}
				catch (System.FormatException ex)
				{
					MessageBox.Show("ERROR: Quantity must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					// TODO: Go back to the purchase dialog so that the user can fix their mistake.
					return;
				}
				try
				{
					cost = Convert.ToDecimal(dlg.GetCost());
				}
				catch (System.FormatException ex)
				{
					MessageBox.Show("ERROR: Cost must be a decimal number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

					// TODO: Go back to the purchase dialog so that the user can fix their mistake.
					return;
				}

				DateTime date = dlg.GetDate();

				// Create a new entry in the Transactions table.
			}
		}
	}
}
