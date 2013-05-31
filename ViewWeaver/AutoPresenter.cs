using System;
using ViewWeaver.Annotations;

namespace ViewWeaver
{
	[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
	public class AutoPresenter<TView> : IDisposable
	{
		private readonly EventMapper<TView> _events;
		protected TView View { get; private set; }

		public AutoPresenter(TView view)
		{
			View = view;
			_events = new EventMapper<TView>(view, this);
			_events.Wire();
		}

		public void Dispose()
		{
			_events.Unwire();
		}
	}
}