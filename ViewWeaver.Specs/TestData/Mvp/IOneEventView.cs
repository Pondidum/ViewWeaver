using System;
using System.Collections.Generic;

namespace ViewWeaver.Specs.TestData.Mvp
{
	public interface IOneEventView
	{
		event EventAction SaveClicked;
	}
}
