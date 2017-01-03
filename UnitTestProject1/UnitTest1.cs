using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Couatl2;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		/// A purchase is added to a database that has no transactions.
		/// </summary>
		[TestMethod]
		public void AddPurchase_FirstXact()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addpurch1.xml");

			// Create the account.
			DataRow newAcct = testApp.CurrDataSet.Tables["Accounts"].NewRow();
			newAcct["Name"] = "Account1";
			newAcct["Institution"] = "Acme Corp.";
			testApp.CurrDataSet.Tables["Accounts"].Rows.Add(newAcct);

			// Create the security.
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = "XYZ";
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);

			UInt32 expType = 1;
			UInt32 expSec = 1; // only symbol so it should always be 1
			decimal expQty = 123.456M;
			decimal expVal = 987.654M;
			decimal expComm = 7.89M;
			DateTime expDate = new DateTime(2016, 9, 4);
			UInt32 expAcct = 1; // only account so it should always be 1
			testApp.AddPurchaseTransaction("Account1", "XYZ", expQty, expVal, expComm, expDate);

			// Verify that the transaction table has only one row.
			DataTable testXact = testApp.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(1, testXact.Rows.Count);

			// Verify the row info.
			DataRow actXact = testApp.CurrDataSet.Tables["Transactions"].Rows[0];
			Assert.AreEqual(1, actXact["ID"]);
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expSec, actXact["Security"]);
			Assert.AreEqual(expQty, actXact["Quantity"]);
			Assert.AreEqual(expVal, actXact["Value"]);
			Assert.AreEqual(expComm, actXact["Fee"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);
		}
	}
}
