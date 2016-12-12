using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;//pjl
using System.IO;//pjl

namespace Couatl2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			System.Diagnostics.Debug.WriteLine("Welcome to Couatl2.");

#if false
			// pjl begin test code
			// based on code from http://csharphelper.com/blog/2015/01/get-stock-prices-from-the-internet-in-c/ 
			string result;
			WebClient wc = new WebClient();
			using (Stream resp = wc.OpenRead("http://download.finance.yahoo.com/d/quotes.csv?s=AAPL+DIS+KO+YHOO&f=sl1d1t1c1"))
			using (StreamReader sr = new StreamReader(resp))
			{
				result = sr.ReadToEnd();
			}
			System.Diagnostics.Debug.WriteLine(result);
			// pjl end test code
#endif

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainGui(new Couatl2App()));
		}
	}
}
