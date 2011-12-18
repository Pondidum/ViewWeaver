using System;

namespace ViewWeaver.Specs.TestData.Classes
{
	public class TwoPublicReadonlyProperties
	{
		private string _firstProperty;
		private int _secondProperty;

		public TwoPublicReadonlyProperties()
		{
			_firstProperty = "firstProperty";
			_secondProperty = 4;
		}

		public TwoPublicReadonlyProperties(String first, int second)
		{
			_firstProperty = first;
			_secondProperty = second;
		}

		public String FirstProperty { get { return _firstProperty; } }
		public int SecondProperty { get { return _secondProperty; } }
	}
}
