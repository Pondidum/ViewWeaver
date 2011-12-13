﻿using System;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.CheckSpecs
{
	public class EnumSpecs
	{
		public class When_passed_an_enum : CheckSpecBase
		{
			Because of = () => ex = Catch.Exception(() => Check.Enum(StringComparison.Ordinal));
			It should_should_do_nothing = () => ex.ShouldBeNull();
		}

		public class When_passed_a_structure : CheckSpecBase
		{
			Because of = () => ex = Catch.Exception(() => Check.Enum(new Test()));
			It should_throw_an_argument_exception = () => ex.ShouldBeOfType<ArgumentException>();
		}

		internal struct Test
		{
			public String Value;
		}
	}
}