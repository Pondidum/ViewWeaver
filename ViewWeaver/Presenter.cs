using System;
using ViewWeaver.Extensions;
using ViewWeaver.Interfaces;

namespace ViewWeaver
{
	public class Presenter<TView> : IDisposable
	{
		public TView View { get { return _view; } }

		private readonly EventAutoWirer<TView> _eventWirer;
		private readonly TView _view;

		public Presenter(TView view)
		{
			Check.Argument(view, "view");

			_view = view;
			_eventWirer = new EventAutoWirer<TView>(view, this);

			_eventWirer.Wire();
		}

		public void Dispose()
		{
			_eventWirer.Unwire();
		}
	}
}