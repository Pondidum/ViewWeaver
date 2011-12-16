using System;

namespace ViewWeaver.Specs.TestData.Classes
{
	public class OnePublicWriteonlyProperty
	{
		private string _test;

		public String Test { set { _test = value; } }
	}
}
