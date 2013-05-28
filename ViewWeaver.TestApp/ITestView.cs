using System;
using System.Windows.Forms;

namespace ViewWeaver.TestApp
{
	public interface ITestView
	{
		String Filename { get; set; }

		event EventAction OkClicked;
		event EventAction CancelClicked;

		DialogResult ShowDialog();
		void Close();
	}

}
