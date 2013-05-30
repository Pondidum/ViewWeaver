using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewWeaver.Specs.TestData.Mvp
{
	public class OneDefinedEventView : IOneEventView
	{
		public event EventAction SaveClicked;
		public event EventAction CancelClicked;

		public IEnumerable<Delegate> SaveSubscribers()
		{
			return SaveClicked == null ? Enumerable.Empty<Delegate>() : SaveClicked.GetInvocationList();
		}

		public IEnumerable<Delegate> CancelSubscribers()
		{
			return CancelClicked == null ? Enumerable.Empty<Delegate>() : CancelClicked.GetInvocationList();
		}
	}
}