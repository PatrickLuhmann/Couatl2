using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

// The assembly name is found in AssemblyInfo.cs. This is how
// C# implements the "friend" concept.
[assembly: InternalsVisibleTo("UnitTestProject1")]

namespace Couatl2
{
	public class Couatl2App
	{
		private string CurrDbFilename;
		internal DataSet CurrDataSet;
		private static UInt32 CurrSchemaVersion = 2;

		public Boolean IsDbOpen
		{
			get { return CurrDbFilename != null; }
		}

		/// <summary>
		/// Open the given database file.
		/// The filename is usually provided by the user, but could also
		/// be stored in a configuration file.
		/// </summary>
		/// <param name="filename">The full name of the database file to open.</param>
		/// <returns></returns>
		public bool OpenDbFile(string filename)
		{
			if (!System.IO.File.Exists(filename))
				return false;

			CloseDbFile();

			CurrDbFilename = filename;
			CurrDataSet = new DataSet();
			CurrDataSet.ReadXml(CurrDbFilename);

			// Verify that this is a valid Couatl2 database file.
			string appName = "";
			try
			{
				DataRow row;
				UInt32 version;
				row = CurrDataSet.Tables["ConfigParams"].Rows.Find("AppName");
				appName = (string)row["Value"];
				System.Diagnostics.Debug.WriteLine("AppName: " + appName);
				row = CurrDataSet.Tables["ConfigParams"].Rows.Find("SchemaVersion");
				version = UInt32.Parse((string)row["Value"]);
				System.Diagnostics.Debug.WriteLine("SchemaVersion: " + row["Value"]);
				if (appName != "Couatl2" || version != CurrSchemaVersion)
				{
					throw new Exception();
				}
				else
				{
					System.Diagnostics.Debug.WriteLine("Valid Couatl2 file selected: " + filename);
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Invalid file selected.\n" + ex.Message);
				CloseDbFile();
				return false;
			}
			return true;
		}

		/// <summary>
		/// Saves the currently-open database file.
		/// If there is no open file, then this function does nothing.
		/// </summary>
		public void SaveDbFile()
		{
			if (CurrDbFilename != null)
			{
				CurrDataSet.WriteXml(CurrDbFilename, XmlWriteMode.WriteSchema);
			}
		}

		/// <summary>
		/// Close the currently-open database file.
		/// The data is saved before the database is closed.
		/// </summary>
		public void CloseDbFile()
		{
			SaveDbFile();
			CurrDbFilename = null;
			if (CurrDataSet != null)
			{
				// Still not sure if need to Dispose or something here.
				CurrDataSet = null;
			}
		}

		/// <summary>
		/// Create a new database and save it to the specified file.
		/// If 'filename' already exists then it will be deleted before
		/// the new database file is created.
		/// </summary>
		/// <param name="filename">The name of the database file to create.</param>
		public void CreateNewDbFile(string filename)
		{
			CloseDbFile();

			// Create a new DataSet with the Anhkheg2 schema.
			DataSet newDb = new DataSet("Couatl2DateFile");
			DataRow row;

			// TABLE: Accounts
			DataTable accounts = newDb.Tables.Add("Accounts");
			accounts.Columns.Add("ID", typeof(UInt32));
			accounts.PrimaryKey = new DataColumn[] { accounts.Columns["ID"] };
			accounts.Columns["ID"].AutoIncrement = true;
			accounts.Columns["ID"].AutoIncrementSeed = 1;
			accounts.Columns["ID"].AutoIncrementStep = 1;
			accounts.Columns.Add("Institution", typeof(String));
			accounts.Columns.Add("Name", typeof(String));
			accounts.Columns.Add("Closed", typeof(Boolean));

			// TABLE: Transactions
			DataTable transactions = newDb.Tables.Add("Transactions");
			transactions.Columns.Add("ID", typeof(UInt32));
			transactions.PrimaryKey = new DataColumn[] { transactions.Columns["ID"] };
			transactions.Columns["ID"].AutoIncrement = true;
			transactions.Columns["ID"].AutoIncrementSeed = 1;
			transactions.Columns["ID"].AutoIncrementStep = 1;
			transactions.Columns.Add("Type", typeof(UInt32));
			transactions.Columns.Add("Security", typeof(UInt32));
			transactions.Columns.Add("Quantity", typeof(Decimal));
			transactions.Columns.Add("Value", typeof(Decimal));
			transactions.Columns.Add("Fee", typeof(Decimal));
			transactions.Columns.Add("Date", typeof(DateTime));
			transactions.Columns.Add("Account", typeof(UInt32));

			// TABLE: Prices
			DataTable prices = newDb.Tables.Add("Prices");
			prices.Columns.Add("ID", typeof(UInt32));
			prices.PrimaryKey = new DataColumn[] { prices.Columns["ID"] };
			prices.Columns["ID"].AutoIncrement = true;
			prices.Columns["ID"].AutoIncrementSeed = 1;
			prices.Columns["ID"].AutoIncrementStep = 1;
			prices.Columns.Add("Security", typeof(UInt32));
			prices.Columns.Add("Price", typeof(Decimal));
			prices.Columns.Add("Date", typeof(DateTime));

			// TABLE: Securities
			DataTable securities = newDb.Tables.Add("Securities");
			securities.Columns.Add("ID", typeof(UInt32));
			securities.PrimaryKey = new DataColumn[] { securities.Columns["ID"] };
			securities.Columns["ID"].AutoIncrement = true;
			securities.Columns["ID"].AutoIncrementSeed = 1;
			securities.Columns["ID"].AutoIncrementStep = 1;
			securities.Columns.Add("Name", typeof(String));
			securities.Columns.Add("Symbol", typeof(String));

			// TABLE: LotAssignments
			DataTable lotAssignments = newDb.Tables.Add("LotAssignments");
			lotAssignments.Columns.Add("ID", typeof(UInt32));
			lotAssignments.PrimaryKey = new DataColumn[] { lotAssignments.Columns["ID"] };
			lotAssignments.Columns["ID"].AutoIncrement = true;
			lotAssignments.Columns["ID"].AutoIncrementSeed = 1;
			lotAssignments.Columns["ID"].AutoIncrementStep = 1;
			lotAssignments.Columns.Add("Buy", typeof(UInt32));
			lotAssignments.Columns.Add("Sell", typeof(UInt32));
			lotAssignments.Columns.Add("Quantity", typeof(Decimal));

			// TABLE: ConfigParams
			DataTable configParameters = newDb.Tables.Add("ConfigParams");
			configParameters.Columns.Add("Name", typeof(String));
			configParameters.PrimaryKey = new DataColumn[] { configParameters.Columns["Name"] };
			configParameters.Columns.Add("Value", typeof(String));

			row = configParameters.NewRow();
			row["Name"] = "AppName";
			row["Value"] = "Couatl2";
			configParameters.Rows.Add(row);

			row = configParameters.NewRow();
			row["Name"] = "SchemaVersion";
			row["Value"] = "2";
			configParameters.Rows.Add(row);

			newDb.WriteXml(filename, XmlWriteMode.WriteSchema);

			CurrDbFilename = filename;
			CurrDataSet = newDb;
		}

		/// <summary>
		/// Return true if 'account' is in the Accounts table; false otherwise
		/// </summary>
		/// <param name="account">The Name to look for.</param>
		/// <returns></returns>
		internal bool FindAccount(string account)
		{
			DataRow[] foundRows = CurrDataSet.Tables["Accounts"].Select("Name = '" + account + "'");
			if (foundRows.Length == 1)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Return true if 'symbol' is in the Securities table; false otherwise
		/// 
		/// This function does not try to correct for uppercase/lowercase; that is
		/// the responsibility of the caller.
		/// </summary>
		/// <param name="symbol">The Symbol to look for.</param>
		/// <returns></returns>
		public bool FindSymbol(string symbol)
		{
			DataRow[] foundRows = CurrDataSet.Tables["Securities"].Select("Symbol = '" + symbol + "'");
			if (foundRows.Length == 1)
				return true;
			else
				return false;
		}

		public bool AddNewSecurity(string sym, string name)
		{
			if (System.Text.RegularExpressions.Regex.IsMatch(sym, @"^[A-Z]{1,5}$"))
			{
				DataRow newSec = CurrDataSet.Tables["Securities"].NewRow();
				newSec["Symbol"] = sym;
				newSec["Name"] = name;
				CurrDataSet.Tables["Securities"].Rows.Add(newSec);
				return true;
			}
			System.Diagnostics.Debug.WriteLine("Symbol is not valid.");
			return false;
		}

		internal bool ProcessPurchaseTransaction(string account, string symbol, decimal quantity, 
			decimal cost, decimal commission, DateTime date)
		{
			// Verify the account name.
			if (!FindAccount(account))
				return false;

			// Verify the symbol.
			symbol = symbol.ToUpper();
			if (!FindSymbol(symbol))
				return false;

			try
			{
				AddPurchaseTransaction(account, symbol, quantity, cost, commission, date);
			}
			catch
			{
				return false;
			}

			SaveDbFile();
			return true;
		}

		/// <summary>
		/// Return a list populated with the account names
		/// </summary>
		/// <returns>A List (of type string) with the names of the accounts in it.</returns>
		public List<string> GetAccountNameList()
		{
			// Go through the rows of the Accounts table and extract the account names.
			List<string> acctNameList = new List<string>();
			DataTable acctTable = CurrDataSet.Tables["Accounts"];

			foreach (DataRow dr in acctTable.Rows)
			{
				acctNameList.Add(dr["Name"].ToString());
			}

			return acctNameList;
		}

		/// <summary>
		/// Return a table with account name, institution, and value
		/// </summary>
		/// <returns>Returns table with account name, institution, and value.</returns>
		public DataTable GetAccountListTable()
		{
			// Start with a copy of the Accounts table.
			DataTable acctList = CurrDataSet.Tables["Accounts"].Copy();

			// Add a column for Value.
			DataColumn value = acctList.Columns.Add("Value");
			// TODO: This is test code to put an arbitrary value into the cell.
			// Replace it with the real code.
			for (int x = 0; x < acctList.Rows.Count; x++)
			{
				acctList.Rows[x]["Value"] = x * 2;
			}

			// Remove the ID column because that has no meaning to the user.
			acctList.PrimaryKey = null;
			acctList.Columns.Remove("ID");

			return acctList;
		}

		/// <summary>
		/// Add a purchase transaction to the database
		/// 
		/// This method does not do any error checking. It assumes that the account and the symbol
		/// are already present in the database. It assumes that the quantity, cost, and date values
		/// are reasonable and make sense within the context of the database.
		/// 
		/// This method does not catch any exceptions.
		/// </summary>
		/// <param name="accountName">The name of the account.</param>
		/// <param name="symbol">The ticket symbol of the security.</param>
		/// <param name="quantity">The number of shares of the security.</param>
		/// <param name="cost">The total cost of the security.</param>
		/// <param name="date">The date on which the security was purchased.</param>
		public void AddPurchaseTransaction(string accountName, string symbol, decimal quantity, 
			decimal cost, decimal commission, DateTime date)
		{
			// Find the ID of the account.
			DataRow[] foundRows = CurrDataSet.Tables["Accounts"].Select("Name = '" + accountName + "'");
			// TODO: This code assumes one row is always returned. What happens if this is not the case?
			UInt32 acctID = Convert.ToUInt32(foundRows[0]["ID"]);

			// Find the ID of the symbol.
			foundRows = CurrDataSet.Tables["Securities"].Select("Symbol = '" + symbol + "'");
			UInt32 secID = Convert.ToUInt32(foundRows[0]["ID"]);

			DataRow newXact = CurrDataSet.Tables["Transactions"].NewRow();
			newXact["Type"] = 1; // 1 = Buy.
			newXact["Security"] = secID;
			newXact["Quantity"] = quantity;
			newXact["Value"] = cost;
			newXact["Fee"] = commission;
			newXact["Date"] = date;
			newXact["Account"] = acctID;
			CurrDataSet.Tables["Transactions"].Rows.Add(newXact);
		}

		public void CreateAccount(string accountName, string institutionName)
		{
			DataRow newAcct = CurrDataSet.Tables["Accounts"].NewRow();
			newAcct["Name"] = accountName;
			newAcct["Institution"] = institutionName;
			CurrDataSet.Tables["Accounts"].Rows.Add(newAcct);

			SaveDbFile();
		}
	}
}
