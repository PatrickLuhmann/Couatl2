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
	public partial class CreateAccountDialog : Form
	{
		public CreateAccountDialog()
		{
			InitializeComponent();
		}

		public string GetAccountName()
		{
			return textBox1.Text;
		}

		public string GetInstitutionName()
		{
			return textBox2.Text;
		}
	}
}
