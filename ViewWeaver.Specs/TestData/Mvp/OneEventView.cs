using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewWeaver.Specs.TestData.Mvp
{
	public class OneEventView : IOneEventView
	{
		public event EventAction SaveClicked;

		public IEnumerable<Delegate> SaveSubscribers()
		{
			return SaveClicked== null ? Enumerable.Empty<Delegate>() : SaveClicked.GetInvocationList();
		}
	}
}
