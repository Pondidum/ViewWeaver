using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ViewWeaver.TestApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());

			using (var view = new TestView())
			using (var pres = new TestPresenter(view))
			{
				pres.Display();
			}

		}
	}
}
