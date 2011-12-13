using System;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.TestData
{
	[Flags()]
	public enum FlagsTest : int
	{
		None = 0,
		One = 1,
		Two = 2,
		Four = 4,
		Eight = 8,
	}
}