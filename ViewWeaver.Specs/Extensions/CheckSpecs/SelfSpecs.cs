using System;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.CheckSpecs
{
	namespace SelfSpecs
	{
		public class When_passed_a_null_value : CheckSpecBase
		{
			Because of = () => ex = Catch.Exception(() => Check.Self(null));
			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_a_non_null_value : CheckSpecBase
		{
			Because of = () => ex = Catch.Exception(() => Check.Self(new object()));
			It should_not_do_anything = () => ex.ShouldBeNull();
		}

	}
}
