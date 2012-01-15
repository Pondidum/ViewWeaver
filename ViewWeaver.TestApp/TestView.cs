using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViewWeaver.TestApp
{
	public partial class TestView : Form, ITestView
	{

		public event EventAction OkClicked;
		public event EventAction CancelClicked;

		public TestView()
		{
			InitializeComponent();
		}

		public string Filename
		{
			get { return txtFilename.Text; }
			set { txtFilename.Text = value; }
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			OkClicked();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			CancelClicked();
		}

	}
}
