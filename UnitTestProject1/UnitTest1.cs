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

		[TestMethod]
		public void GetSecurityPrice_OneRow()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-getsecprice1.xml");

			// Create the security.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID = Convert.ToUInt32(newSec["ID"]);

			// Add the price
			decimal expPrice = 123.45M;
			DataRow newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 11);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			decimal actPrice = testApp.GetSecurityPrice(testSecSym);

			// Verify
			Assert.AreEqual(expPrice, actPrice);
		}

		[TestMethod]
		public void GetSecurityPrice_OneSymFiveRows()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-getsecprice1x5.xml");

			// Create the security.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID = Convert.ToUInt32(newSec["ID"]);

			// Add the prices
			decimal expPrice = 123.45M;
			DataRow newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 7);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			expPrice = 45.98M;
			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 8);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			expPrice = -45.98M;
			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 9);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			expPrice = 1.00M;
			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 10);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			expPrice = 98765.4321M;
			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 11);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			// Execute code under test.
			decimal actPrice = testApp.GetSecurityPrice(testSecSym);

			// Verify
			Assert.AreEqual(expPrice, actPrice);
		}

		[TestMethod]
		public void GetSecurityPrice_OneSymFiveRows_OOO()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-getsecprice1x5.xml");

			// Create the security.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID = Convert.ToUInt32(newSec["ID"]);

			// Add the prices
			decimal expPrice = 98714.4821M;

			DataRow newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = 123.45M;
			newPrice["Date"] = new DateTime(2017, 1, 7);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = 45.98M;
			newPrice["Date"] = new DateTime(2017, 1, 8);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			// this is the one
			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2017, 1, 11);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = 45.98M;
			newPrice["Date"] = new DateTime(2017, 1, 9);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID;
			newPrice["Price"] = 1.00M;
			newPrice["Date"] = new DateTime(2017, 1, 10);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			// Execute code under test.
			decimal actPrice = testApp.GetSecurityPrice(testSecSym);

			// Verify
			Assert.AreEqual(expPrice, actPrice);
		}

		[TestMethod]
		public void GetSecurityPrice_ManySymManyRows()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-getsecprice1.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "ZYX";
			newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Xcellent Xylophones Corp.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_ZYX = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "FUD";
			newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Beware And Be Aware Co.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_FUD = Convert.ToUInt32(newSec["ID"]);

			// Add the prices
			decimal expPrice = 17.76M;

			DataRow newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_ZYX;
			newPrice["Price"] = 1.11M;
			newPrice["Date"] = new DateTime(2017, 1, 11);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_FUD;
			newPrice["Price"] = 2.22M;
			newPrice["Date"] = new DateTime(1939, 10, 22);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_XYZ;
			newPrice["Price"] = 3.33M;
			newPrice["Date"] = new DateTime(2017, 1, 11);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_FUD;
			newPrice["Price"] = 4.44M;
			newPrice["Date"] = new DateTime(1972, 7, 3);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_ZYX;
			newPrice["Price"] = 4.44M;
			newPrice["Date"] = new DateTime(2017, 1, 10);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			// this is the one
			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_FUD;
			newPrice["Price"] = expPrice;
			newPrice["Date"] = new DateTime(2015, 1, 11);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_FUD;
			newPrice["Price"] = 6.66M;
			newPrice["Date"] = new DateTime(2015, 1, 10);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_XYZ;
			newPrice["Price"] = 7.77M;
			newPrice["Date"] = new DateTime(2017, 1, 10);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_FUD;
			newPrice["Price"] = 8.88M;
			newPrice["Date"] = new DateTime(2013, 11, 4);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_XYZ;
			newPrice["Price"] = 9.99M;
			newPrice["Date"] = new DateTime(2017, 1, 9);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			newPrice = testApp.CurrDataSet.Tables["Prices"].NewRow();
			newPrice["Security"] = secID_ZYX;
			newPrice["Price"] = 10.1010M;
			newPrice["Date"] = new DateTime(2017, 1, 9);
			testApp.CurrDataSet.Tables["Prices"].Rows.Add(newPrice);

			// Execute the code under test.
			decimal actPrice = testApp.GetSecurityPrice("FUD");

			// Verify
			Assert.AreEqual(expPrice, actPrice);
		}

		[TestMethod]
		public void GetSecurityIdFromSymbol_Test()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-getsecid.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "ZYX";
			newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Xcellent Xylophones Corp.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_ZYX = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "FUD";
			newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Beware And Be Aware Co.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_FUD = Convert.ToUInt32(newSec["ID"]);

			Assert.AreEqual(secID_FUD, testApp.GetSecurityIdFromSymbol("FUD"));
			Assert.AreEqual(secID_XYZ, testApp.GetSecurityIdFromSymbol("xYz"));
			Assert.AreEqual(secID_ZYX, testApp.GetSecurityIdFromSymbol("zyx"));
		}

		[TestMethod]
		public void AddPrice_ClosingNew()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addprice-cn.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			DateTime date = DateTime.Now;

			// Execute the code under test.
			testApp.AddPrice("XYZ", 123.45M, date, true);

			// Verify
			Assert.AreEqual(1, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp.CurrDataSet.Tables["Prices"].Rows[0];
			Assert.AreEqual(123.45M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_IntraNew()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addprice-in.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			DateTime date = DateTime.Now;

			// Execute the code under test.
			testApp.AddPrice("XYZ", 123.45M, date, false);

			// Verify
			Assert.AreEqual(1, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp.CurrDataSet.Tables["Prices"].Rows[0];
			Assert.AreEqual(123.45M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_ClosingReplacesIntra()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addprice-cri.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			// Create the pre-existing intra-day price.
			DateTime date = new DateTime(2001, 2, 3);
			testApp.AddPrice("XYZ", 123.45M, date, false);

			// Execute the code under test.
			testApp.AddPrice("XYZ", 291.00M, date, true);

			// Verify
			Assert.AreEqual(1, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp.CurrDataSet.Tables["Prices"].Rows[0];
			Assert.AreEqual(291.00M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_IntraReplacesIntra()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addprice-iri.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			// Create the pre-existing intra-day price.
			DateTime date = new DateTime(2001, 2, 3);
			testApp.AddPrice("XYZ", 123.45M, date, false);

			// Execute the code under test.
			testApp.AddPrice("XYZ", 291.00M, date, false);

			// Verify
			Assert.AreEqual(1, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp.CurrDataSet.Tables["Prices"].Rows[0];
			Assert.AreEqual(291.00M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_IntraDoesntReplacesClosing()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addprice-idrc.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			// Create the pre-existing closing price.
			DateTime date = new DateTime(2001, 2, 3);
			testApp.AddPrice("XYZ", 123.45M, date, true);

			// Execute the code under test.
			testApp.AddPrice("XYZ", 291.00M, date, false);

			// Verify
			Assert.AreEqual(1, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			DataRow price = testApp.CurrDataSet.Tables["Prices"].Rows[0];
			Assert.AreEqual(123.45M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}

		[TestMethod]
		public void AddPrice_MultiplePrices()
		{
			Couatl2App testApp = new Couatl2App();
			testApp.CreateNewDbFile("test-addprice-mp.xml");

			// Create the securities.
			string testSecSym = "XYZ";
			DataRow newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Big Band Inc.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_XYZ = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "ZYX";
			newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Xcellent Xylophones Corp.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_ZYX = Convert.ToUInt32(newSec["ID"]);

			testSecSym = "FUD";
			newSec = testApp.CurrDataSet.Tables["Securities"].NewRow();
			newSec["Name"] = "Beware And Be Aware Co.";
			newSec["Symbol"] = testSecSym;
			testApp.CurrDataSet.Tables["Securities"].Rows.Add(newSec);
			UInt32 secID_FUD = Convert.ToUInt32(newSec["ID"]);

			// Create the pre-existing prices.
			DateTime date;

			date = new DateTime(2001, 2, 3);
			testApp.AddPrice("XYZ", 123.45M, date, true);
			date = new DateTime(2000, 2, 4);
			testApp.AddPrice("XYZ", 127.92M, date, true);
			date = new DateTime(2017, 2, 3);
			testApp.AddPrice("XYZ", 58.702M, date, true);

			date = new DateTime(1942, 10, 16);
			testApp.AddPrice("XYZ", 716.388M, date, false);
			date = new DateTime(1971, 9, 10);
			testApp.AddPrice("XYZ", 483.649M, date, false);
			date = new DateTime(2012, 6, 17);
			testApp.AddPrice("XYZ", 873.379M, date, false);

			date = new DateTime(2003, 2, 3);
			testApp.AddPrice("ZYX", 260.858M, date, true);
			date = new DateTime(1945, 2, 4);
			testApp.AddPrice("ZYX", 581.811M, date, true);
			date = new DateTime(2001, 2, 3);
			testApp.AddPrice("ZYX", 53.213M, date, true);

			date = new DateTime(1996, 1, 13);
			testApp.AddPrice("ZYX", 311.466M, date, false);
			date = new DateTime(1989, 4, 19);
			testApp.AddPrice("ZYX", 988.218M, date, false);
			date = new DateTime(1994, 6, 24);
			testApp.AddPrice("ZYX", 424.726M, date, false);

			date = new DateTime(1960, 3, 23);
			testApp.AddPrice("FUD", 206.752M, date, true);
			date = new DateTime(2000, 8, 14);
			testApp.AddPrice("FUD", 652.054M, date, true);
			date = new DateTime(1942, 12, 31);
			testApp.AddPrice("FUD", 112.201M, date, true);

			date = new DateTime(2014, 11, 8);
			testApp.AddPrice("FUD", 873.474M, date, false);
			date = new DateTime(1989, 9, 23);
			testApp.AddPrice("FUD", 895.135M, date, false);
			date = new DateTime(1973, 4, 12);
			testApp.AddPrice("FUD", 213.749M, date, false);

			// TODO: I'm not sure I really like writing a test this way.
			// Manually keeping track of Rows offsets; what if something changes?
			//See if there is a better way to do it.

			DataRow price;

			// New closing price.
			date = new DateTime(1965, 1, 1);
			testApp.AddPrice("XYZ", 11.11M, date, true);

			Assert.AreEqual(19, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp.CurrDataSet.Tables["Prices"].Rows[18];
			Assert.AreEqual(11.11M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));

			// New intra-day price.
			date = new DateTime(2000, 8, 13);
			testApp.AddPrice("FUD", 22.22M, date, false);

			Assert.AreEqual(20, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp.CurrDataSet.Tables["Prices"].Rows[19];
			Assert.AreEqual(22.22M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));

			// Closing price replaces existing intra-day price.
			date = new DateTime(1989, 4, 19);
			testApp.AddPrice("ZYX", 33.33M, date, true);

			Assert.AreEqual(20, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp.CurrDataSet.Tables["Prices"].Rows[10];
			Assert.AreEqual(33.33M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));

			// Intra-day price replaces existing intra-day price.
			date = new DateTime(1942, 10, 16);
			testApp.AddPrice("XYZ", 44.44M, date, false);

			Assert.AreEqual(20, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp.CurrDataSet.Tables["Prices"].Rows[3];
			Assert.AreEqual(44.44M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(false, Convert.ToBoolean(price["Closing"]));

			// Intra-day price *doesn't* replace existing closing price.
			date = new DateTime(1960, 3, 23);
			testApp.AddPrice("FUD", 55.55M, date, false);

			Assert.AreEqual(20, testApp.CurrDataSet.Tables["Prices"].Rows.Count);
			price = testApp.CurrDataSet.Tables["Prices"].Rows[12];
			Assert.AreEqual(206.752M, Convert.ToDecimal(price["Price"]));
			date = date.Date;
			Assert.AreEqual(date, Convert.ToDateTime(price["Date"]));
			Assert.AreEqual(true, Convert.ToBoolean(price["Closing"]));
		}
	}
}
