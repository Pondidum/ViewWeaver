using System;

namespace ViewWeaver.Specs.TestData.Classes
{
	public class TwoPublicReadonlyProperties
	{
		private string _firstProperty;
		private int _secondProperty;

		public String FirstProperty { get { return _firstProperty; } }
		public int SecondProperty { get { return _secondProperty; } }
	}
}
