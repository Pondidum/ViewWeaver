namespace ViewWeaver.TestApp
{
	public class TestPresenter : AutoPresenter<ITestView>
	{
		public TestPresenter(ITestView view) : base(view)
		{
		}

		public void Display()
		{
			View.ShowDialog();
		}

		private void OnOkClicked()
		{
			View.Close();
		}

		private void OnCancelClicked()
		{
			View.Close();
		}
	}
}
