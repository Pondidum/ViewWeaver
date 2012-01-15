using System;

namespace ViewWeaver.TestApp
{
	public interface ITestView
	{
		String Filename { get; set; }

		event EventAction OkClicked;
		event EventAction CancelClicked;
	}

}
