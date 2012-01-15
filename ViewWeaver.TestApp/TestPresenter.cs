using System;

namespace ViewWeaver.TestApp
{
	public class TestPresenter : IDisposable
	{
		private readonly ITestView _view;
		private readonly EventAutoWirer<ITestView> _autoWirer;

		public TestPresenter(ITestView view)
		{
			_view = view;
			_autoWirer = new EventAutoWirer<ITestView>(view, this);
			_autoWirer.Wire();
		}

		private void OnOkClicked()
		{
			
		}

		private void OnCancelClicked()
		{
			
		}

		public void Dispose()
		{
			_autoWirer.Unwire();
		}
	}
}
