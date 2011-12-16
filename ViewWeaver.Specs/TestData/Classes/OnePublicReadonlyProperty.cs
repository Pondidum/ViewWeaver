using System;

namespace ViewWeaver.Specs.TestData.Classes
{
	public class OnePublicReadonlyProperty
	{
		private string _test;

		public OnePublicReadonlyProperty(String value) { _test = value; }
		
		public String Test { get { return _test; } }
	}
}
