using System;

namespace ViewWeaver
{
	[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
	public class AutoPresenter<TView> : IDisposable
	{
		private readonly EventAutoWirer<TView> _events;
		protected TView View { get; private set; }

		public AutoPresenter(TView view)
		{
			View = view;
			_events = new EventAutoWirer<TView>(view, this);
			_events.Wire();
		}

		public void Dispose()
		{
			_events.Unwire();
		}
	}
}