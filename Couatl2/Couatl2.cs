using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Couatl2
{
	public class Couatl2App
	{
		private string CurrDbFilename;
		private DataSet CurrDataSet;
		private static UInt32 CurrSchemaVersion = 1;

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
			row["Value"] = "1";
			configParameters.Rows.Add(row);

			newDb.WriteXml(filename, XmlWriteMode.WriteSchema);

			CurrDbFilename = filename;
			CurrDataSet = newDb;
		}

		public DataTable GetAccountListTable()
		{
			//DataTable acctList = new DataTable();

			return CurrDataSet.Tables["Accounts"];
		}
	}
}
