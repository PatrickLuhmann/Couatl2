using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Couatl2;
using System.Collections.Generic;

namespace UnitTestProject1
{
	[TestClass]
	public class UnitTest1
	{
		Couatl2App testApp2;
		UInt32 acctID_GAPT;
		UInt32 secID_XYZ, secID_ZYX, secID_FUD;

		[TestInitialize]
		public void Init()
		{
			testApp2 = new Couatl2App();
			testApp2.CreateNewDbFile("unit-test.xml");

			// Create the test accounts.
			DataRow newAcct = testApp2.CurrDataSet.Tables["Accounts"].NewRow();
			newAcct["Name"] = "Account1";
			newAcct["Institution"] = "Institution1";
			testApp2.CurrDataSet.Tables["Accounts"].Rows.Add(newAcct);

			newAcct = testApp2.CurrDataSet.Tables["Accounts"].NewRow();
			newAcct["Name"] = "Account2";
			newAcct["Institution"] = "Institution2";
			testApp2.CurrDataSet.Tables["Accounts"].Rows.Add(newAcct);
			UInt32 expId = Convert.ToUInt32(newAcct["ID"]);

			newAcct = testApp2.CurrDataSet.Tables["Accounts"].NewRow();
			newAcct["Name"] = "Account3";
			newAcct["Institution"] = "Institution3";
			testApp2.CurrDataSet.Tables["Accounts"].Rows.Add(newAcct);

			newAcct = testApp2.CurrDataSet.Tables["Accounts"].NewRow();
			newAcct["Name"] = "GAPT";
			newAcct["Institution"] = "Institution4";
			testApp2.CurrDataSet.Tables["Accounts"].Rows.Add(newAcct);
			acctID_GAPT = Convert.ToUInt32(newAcct["ID"]);

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp2.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp2.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "ZYX";
			newSec = testApp2.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Xcellent Xylophones Corp.";
			newSec["Symbol"] = testSecSym;
			testApp2.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			secID_ZYX = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "FUD";
			newSec = testApp2.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Beware And Be Aware Co.";
			newSec["Symbol"] = testSecSym;
			testApp2.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			secID_FUD = Convert.ToUInt32(newSec["ID"]);

			// Create the pre-existing prices. Multiple tests depend on the prices
			// being exactly this way, so don't change what is here without good
			// reason or understanding how it will affect all of the tests.
			DateTime date;

			date = new DateTime(2001, 2, 3);
			testApp2.AddPrice("XYZ", 123.45M, date, true);
			date = new DateTime(2000, 2, 4);
			testApp2.AddPrice("XYZ", 127.92M, date, true);
			date = new DateTime(2017, 2, 3);
			testApp2.AddPrice("XYZ", 58.702M, date, true);

			date = new DateTime(1942, 10, 16);
			testApp2.AddPrice("XYZ", 716.388M, date, false);
			date = new DateTime(1971, 9, 10);
			testApp2.AddPrice("XYZ", 483.649M, date, false);
			date = new DateTime(2012, 6, 17);
			testApp2.AddPrice("XYZ", 873.379M, date, false);

			date = new DateTime(2003, 2, 3);
			testApp2.AddPrice("ZYX", 260.858M, date, true);
			date = new DateTime(1945, 2, 4);
			testApp2.AddPrice("ZYX", 581.811M, date, true);
			date = new DateTime(2001, 2, 3);
			testApp2.AddPrice("ZYX", 53.213M, date, true);

			date = new DateTime(1996, 1, 13);
			testApp2.AddPrice("ZYX", 311.466M, date, false);
			date = new DateTime(1989, 4, 19);
			testApp2.AddPrice("ZYX", 988.218M, date, false);
			date = new DateTime(1994, 6, 24);
			testApp2.AddPrice("ZYX", 424.726M, date, false);

			date = new DateTime(1960, 3, 23);
			testApp2.AddPrice("FUD", 206.752M, date, true);
			date = new DateTime(2000, 8, 14);
			testApp2.AddPrice("FUD", 652.054M, date, true);
			date = new DateTime(1942, 12, 31);
			testApp2.AddPrice("FUD", 112.201M, date, true);

			date = new DateTime(2014, 11, 8);
			testApp2.AddPrice("FUD", 17.76M, date, false);
			date = new DateTime(1989, 9, 23);
			testApp2.AddPrice("FUD", 895.135M, date, false);
			date = new DateTime(1973, 4, 12);
			testApp2.AddPrice("FUD", 213.749M, date, false);

			// Create some transactions.

			date = new DateTime(2017, 1, 1);
			DataRow newXact = testApp2.CurrDataSet.Tables["Transactions"].NewRow();
			newXact["Type"] = (UInt32)Couatl2App.TransactionType.Deposit;
			newXact["Security"] = 0;
			newXact["Quantity"] = 0;
			newXact["Value"] = 10000.00M;
			newXact["Fee"] = 0;
			newXact["Date"] = date;
			newXact["Account"] = acctID_GAPT;
			testApp2.CurrDataSet.Tables["Transactions"].Rows.Add(newXact);

			date = new DateTime(2017, 1, 6);
			newXact = testApp2.CurrDataSet.Tables["Transactions"].NewRow();
			newXact["Type"] = (UInt32)Couatl2App.TransactionType.Buy;
			newXact["Security"] = secID_XYZ;
			newXact["Quantity"] = 100;
			newXact["Value"] = 1000.00M;
			newXact["Fee"] = 7.00M;
			newXact["Date"] = date;
			newXact["Account"] = acctID_GAPT;
			testApp2.CurrDataSet.Tables["Transactions"].Rows.Add(newXact);

			date = new DateTime(2017, 1, 11);
			newXact = testApp2.CurrDataSet.Tables["Transactions"].NewRow();
			newXact["Type"] = (UInt32)Couatl2App.TransactionType.Sell;
			newXact["Security"] = secID_XYZ;
			newXact["Quantity"] = 40;
			newXact["Value"] = 440.00M;
			newXact["Fee"] = 7.00M;
			newXact["Date"] = date;
			newXact["Account"] = acctID_GAPT;
			testApp2.CurrDataSet.Tables["Transactions"].Rows.Add(newXact);
		}

		[TestCleanup]
		public void Clean()
		{
			testApp2.CloseDbFile();
		}

		[TestMethod]
		public void AddNewSecurity_ValidSym()
		{
			int numSec = testApp2.CurrDataSet.Tables["Securities"].Rows.Count;

			bool res = testApp2.AddNewSecurity("TEST", "Tasty Test Inc");

			Assert.AreEqual(true, res);
			Assert.AreEqual(numSec + 1, testApp2.CurrDataSet.Tables["Securities"].Rows.Count);
		}

		[TestMethod]
		public void AddNewSecurity_InvalidSym()
		{
			int numSec = testApp2.CurrDataSet.Tables["Securities"].Rows.Count;

			bool res = testApp2.AddNewSecurity("N0NUM", "No numbers allowed (at this time)");
			Assert.AreEqual(false, res);
			Assert.AreEqual(numSec, testApp2.CurrDataSet.Tables["Securities"].Rows.Count);

			res = testApp2.AddNewSecurity("NO$YM", "No symbols allowed");
			Assert.AreEqual(false, res);
			Assert.AreEqual(numSec, testApp2.CurrDataSet.Tables["Securities"].Rows.Count);

			res = testApp2.AddNewSecurity("TOLONG", "Too long, 5 char max");
			Assert.AreEqual(false, res);
			Assert.AreEqual(numSec, testApp2.CurrDataSet.Tables["Securities"].Rows.Count);

			res = testApp2.AddNewSecurity("NOLoW", "No lower case letters allowed");
			Assert.AreEqual(false, res);
			Assert.AreEqual(numSec, testApp2.CurrDataSet.Tables["Securities"].Rows.Count);

			res = testApp2.AddNewSecurity("", "Too short, 1 char min");
			Assert.AreEqual(false, res);
			Assert.AreEqual(numSec, testApp2.CurrDataSet.Tables["Securities"].Rows.Count);
		}

		[TestMethod]
		public void GetAccountPositionTable_OnePosInOneAcct()
		{
			DataTable dstPosTable = testApp2.GetAccountPositionTable("GAPT");
			Assert.AreEqual(1, dstPosTable.Rows.Count);
			Assert.AreEqual("XYZ", dstPosTable.Rows[0]["Security"]);
			Assert.AreEqual(60.0M, dstPosTable.Rows[0]["Quantity"]);
			Assert.AreEqual(3522.12M, dstPosTable.Rows[0]["Value"]);
		}

		[TestMethod]
		public void AddDepositCashTransaction_Valid()
		{
			UInt32 expType = (UInt32)Couatl2App.TransactionType.Deposit;
			decimal expValue = 123.45M;
			DateTime expDate = new DateTime(2017, 7, 12);
			UInt32 expAcct = 1;
			int expNumRows = testApp2.CurrDataSet.Tables["Transactions"].Rows.Count;
			bool res = testApp2.ProcessDepositCashTransaction("Account1", expValue, expDate);
			Assert.AreEqual(true, res);
			
			// Verify that the transaction table has one additional row.
			DataTable testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 1, testXact.Rows.Count);

			// Verify the row info.
			DataRow actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows];
			Assert.AreEqual(expNumRows + 1, actXact["ID"]); // increments each time
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expValue, actXact["Value"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);

			// Try another transaction.
			expValue = 9876.54M;
			expDate = new DateTime(2016, 10, 31);
			expAcct = 2;
			res = testApp2.ProcessDepositCashTransaction("Account2", expValue, expDate);
			Assert.AreEqual(true, res);

			// Verify that the transaction table now has two additional rows.
			testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 2, testXact.Rows.Count);

			// Verify the row info.
			actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows + 1];
			Assert.AreEqual(expNumRows + 2, actXact["ID"]); // increments each time
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expValue, actXact["Value"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);

			// Try yet another transaction.
			expValue = 2461.334M;
			expDate = new DateTime(2015, 3, 14);
			expAcct = 3;
			res = testApp2.ProcessDepositCashTransaction("Account3", expValue, expDate);
			Assert.AreEqual(true, res);

			// Verify that the transaction table now has three additional rows.
			testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 3, testXact.Rows.Count);

			// Verify the row info.
			actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows + 2];
			Assert.AreEqual(expNumRows + 3, actXact["ID"]); // increments each time
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expValue, actXact["Value"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);
		}

		[TestMethod]
		public void AddCashDividendTransaction_Valid()
		{
			UInt32 expType = (UInt32)Couatl2App.TransactionType.Dividend;
			decimal expValue = 123.45M;
			UInt32 expSec = 1;
			DateTime expDate = new DateTime(2017, 8, 7);
			UInt32 expAcct = 1;
			int expNumRows = testApp2.CurrDataSet.Tables["Transactions"].Rows.Count;
			bool res = testApp2.ProcessRecordCashDividendTransaction("Account1", "XYZ", expValue, expDate);
			Assert.AreEqual(true, res);

			// Verify that the transaction table has one additional row.
			DataTable testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 1, testXact.Rows.Count);

			// Verify the row info.
			DataRow actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows];
			Assert.AreEqual(expNumRows + 1, actXact["ID"]); // increments each time
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expSec, actXact["Security"]);
			Assert.AreEqual(expValue, actXact["Value"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);

			// Try another transaction.
			expValue = 9876.54M;
			expSec = 2;
			expDate = new DateTime(2016, 10, 31);
			expAcct = 2;
			res = testApp2.ProcessRecordCashDividendTransaction("Account2", "ZYX", expValue, expDate);
			Assert.AreEqual(true, res);

			// Verify that the transaction table now has two additional rows.
			testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 2, testXact.Rows.Count);

			// Verify the row info.
			actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows + 1];
			Assert.AreEqual(expNumRows + 2, actXact["ID"]); // increments each time
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expSec, actXact["Security"]);
			Assert.AreEqual(expValue, actXact["Value"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);

			// Try yet another transaction.
			expValue = 2461.334M;
			expSec = 3;
			expDate = new DateTime(2015, 3, 14);
			expAcct = 3;
			res = testApp2.ProcessRecordCashDividendTransaction("Account3", "FUD", expValue, expDate);
			Assert.AreEqual(true, res);

			// Verify that the transaction table now has three additional rows.
			testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 3, testXact.Rows.Count);

			// Verify the row info.
			actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows + 2];
			Assert.AreEqual(expNumRows + 3, actXact["ID"]); // increments each time
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expSec, actXact["Security"]);
			Assert.AreEqual(expValue, actXact["Value"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);
		}

		[TestMethod]
		public void AddCashDividendTransaction_InvalidSymbol()
		{
			decimal expValue = 2.23M;
			DateTime expDate = new DateTime(2017, 8, 7);
			bool res = testApp2.ProcessRecordCashDividendTransaction("Account1", "BLAH", expValue, expDate);
			Assert.AreEqual(false, res);
		}

		[TestMethod]
		public void GetAccountNameList_AllAccounts()
		{
			List<string> actList;

			actList = testApp2.GetAccountNameList();
			Assert.AreEqual(4, actList.Count);
			Assert.AreEqual("Account1", actList[0]);
			Assert.AreEqual("Account2", actList[1]);
			Assert.AreEqual("Account3", actList[2]);
			Assert.AreEqual("GAPT", actList[3]);
		}

		[TestMethod]
		public void GetAccountNameList_NoAccounts()
		{
			List<string> actList;

			// Can't use the default app obj because it has accounts.
			Couatl2App myApp = new Couatl2App();

			// Invoke MUT before a DB file is created.
			actList = myApp.GetAccountNameList();
			Assert.AreEqual(0, actList.Count);

			// Create a new DB file but don't create any accounts.
			myApp.CreateNewDbFile("test-no-accounts");
			actList = myApp.GetAccountNameList();
			Assert.AreEqual(0, actList.Count);
		}

		[TestMethod]
		public void GetSymbolFromSecurityId_All()
		{
			Assert.AreEqual("FUD", testApp2.GetSymbolFromSecurityId(secID_FUD));
			Assert.AreEqual("XYZ", testApp2.GetSymbolFromSecurityId(secID_XYZ));
			Assert.AreEqual("ZYX", testApp2.GetSymbolFromSecurityId(secID_ZYX));
			Assert.AreEqual(null, testApp2.GetSymbolFromSecurityId(2112));
		}

		/// <summary>
		/// The account name is in the table and returns the correct ID.
		/// </summary>
		[TestMethod]
		public void GetAccountIdFromName_Present()
		{
			UInt32 actId;

			// Invoke the method under test.
			actId = testApp2.GetAccountIdFromName("Account2");
			Assert.AreEqual(2U, actId);

			// Invoke the method under test.
			actId = testApp2.GetAccountIdFromName("Account1");
			Assert.AreEqual(1U, actId);

			// Invoke the method under test.
			actId = testApp2.GetAccountIdFromName("Account3");
			Assert.AreEqual(3U, actId);
		}

		/// <summary>
		/// The account name is not in the table and returns 0.
		/// </summary>
		[TestMethod]
		public void GetAccountIdFromName_NotPresent()
		{
			UInt32 expId = 0;

			// Invoke the method under test.
			UInt32 actId = testApp2.GetAccountIdFromName("DoesNotExist");

			// Verify.
			Assert.AreEqual(expId, actId);
		}

		/// <summary>
		/// A purchase is added to a database that has no transactions.
		/// </summary>
		[TestMethod]
		public void AddPurchase_FirstXact()
		{
			int expNumRows = testApp2.CurrDataSet.Tables["Transactions"].Rows.Count;

			UInt32 expType = (UInt32)Couatl2App.TransactionType.Buy;
			UInt32 expSec = secID_XYZ;
			decimal expQty = 123.456M;
			decimal expVal = 987.654M;
			decimal expComm = 7.89M;
			DateTime expDate = new DateTime(2016, 9, 4);
			UInt32 expAcct = 1;

			testApp2.AddPurchaseTransaction("Account1", "XYZ", expQty, expVal, expComm, expDate);

			// Verify that the transaction table has only one additional row.
			DataTable testXact = testApp2.CurrDataSet.Tables["Transactions"];
			Assert.AreEqual(expNumRows + 1, testXact.Rows.Count);

			// Verify the row info.
			DataRow actXact = testApp2.CurrDataSet.Tables["Transactions"].Rows[expNumRows];
			Assert.AreEqual(expNumRows + 1, actXact["ID"]);
			Assert.AreEqual(expType, actXact["Type"]);
			Assert.AreEqual(expSec, actXact["Security"]);
			Assert.AreEqual(expQty, actXact["Quantity"]);
			Assert.AreEqual(expVal, actXact["Value"]);
			Assert.AreEqual(expComm, actXact["Fee"]);
			Assert.AreEqual(expDate, actXact["Date"]);
			Assert.AreEqual(expAcct, actXact["Account"]);
		}

		[TestMethod]
		public void GetPrice_ManySymManyRows()
		{
			// Execute the code under test.
			decimal actPrice = testApp2.GetPrice("FUD");
			Assert.AreEqual(17.76M, actPrice);

			actPrice = testApp2.GetPrice("XYZ");
			Assert.AreEqual(58.702M, actPrice);

			actPrice = testApp2.GetPrice("ZYX");
			Assert.AreEqual(260.858M, actPrice);
		}

		[TestMethod]
		public void GetSecurityIdFromSymbol_Test()
		{
			Assert.AreEqual(secID_FUD, testApp2.GetSecurityIdFromSymbol("FUD"));
			Assert.AreEqual(secID_XYZ, testApp2.GetSecurityIdFromSymbol("xYz"));
			Assert.AreEqual(secID_ZYX, testApp2.GetSecurityIdFromSymbol("zyx"));
		}

		[TestMethod]
		public void AddPrice_ClosingNew()
		{
			// Calculate the expected number of rows.
			int expNumRows = 1 + testApp2.CurrDataSet.Tables["Prices"].Rows.Count;

			DateTime date = DateTime.Now;

			// Execute the code under test.
			testApp2.AddPrice("XYZ", 123.45M, date, true);

			// Verify
			Assert.AreEqual(expNumRows, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp2.CurrDataSet.Tables["Prices"].Rows[expNumRows - 1];
			Assert.AreEqual(123.45M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_IntraNew()
		{
			// Calculate the expected number of rows.
			int expNumRows = 1 + testApp2.CurrDataSet.Tables["Prices"].Rows.Count;

			DateTime date = DateTime.Now;

			// Execute the code under test.
			testApp2.AddPrice("XYZ", 123.45M, date, false);

			// Verify
			Assert.AreEqual(expNumRows, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp2.CurrDataSet.Tables["Prices"].Rows[expNumRows - 1];
			Assert.AreEqual(123.45M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_ClosingReplacesIntra()
		{
			// This test must not change the number of rows.
			int expNumRows = testApp2.CurrDataSet.Tables["Prices"].Rows.Count;

			// Execute the code under test.
			DateTime date = new DateTime(1942, 10, 16);
			testApp2.AddPrice("XYZ", 214, date, true);

			// Verify
			Assert.AreEqual(expNumRows, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp2.CurrDataSet.Tables["Prices"].Rows[3];
			Assert.AreEqual(214, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_IntraReplacesIntra()
		{
			// This test must not change the number of rows.
			int expNumRows = testApp2.CurrDataSet.Tables["Prices"].Rows.Count;

			// Execute the code under test.
			DateTime date = new DateTime(1942, 10, 16);
			testApp2.AddPrice("XYZ", 291.00M, date, false);

			// Verify
			Assert.AreEqual(expNumRows, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp2.CurrDataSet.Tables["Prices"].Rows[3];
			Assert.AreEqual(291.00M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_IntraDoesntReplacesClosing()
		{
			// This test must not change the number of rows.
			int expNumRows = testApp2.CurrDataSet.Tables["Prices"].Rows.Count;

			// Execute the code under test.
			DateTime date = new DateTime(2001, 2, 3);
			testApp2.AddPrice("XYZ", 291.00M, date, false);

			// Verify
			Assert.AreEqual(expNumRows, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			// Assume this price is always first in the table.
			DataRow price = testApp2.CurrDataSet.Tables["Prices"].Rows[0];
			Assert.AreEqual(123.45M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_MultiplePrices()
		{
			DateTime date;
			DataRow price;

			// New closing price.
			date = new DateTime(1965, 1, 1);
			testApp2.AddPrice("XYZ", 11.11M, date, true);

			Assert.AreEqual(19, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp2.CurrDataSet.Tables["Prices"].Rows[18];
			Assert.AreEqual(11.11M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));

			// New intra-day price.
			date = new DateTime(2000, 8, 13);
			testApp2.AddPrice("FUD", 22.22M, date, false);

			Assert.AreEqual(20, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp2.CurrDataSet.Tables["Prices"].Rows[19];
			Assert.AreEqual(22.22M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));

			// Closing price replaces existing intra-day price.
			date = new DateTime(1989, 4, 19);
			testApp2.AddPrice("ZYX", 33.33M, date, true);

			Assert.AreEqual(20, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp2.CurrDataSet.Tables["Prices"].Rows[10];
			Assert.AreEqual(33.33M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));

			// Intra-day price replaces existing intra-day price.
			date = new DateTime(1942, 10, 16);
			testApp2.AddPrice("XYZ", 44.44M, date, false);

			Assert.AreEqual(20, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp2.CurrDataSet.Tables["Prices"].Rows[3];
			Assert.AreEqual(44.44M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));

			// Intra-day price *doesn't* replace existing closing price.
			date = new DateTime(1960, 3, 23);
			testApp2.AddPrice("FUD", 55.55M, date, false);

			Assert.AreEqual(20, testApp2.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp2.CurrDataSet.Tables["Prices"].Rows[12];
			Assert.AreEqual(206.752M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}
	}
}
