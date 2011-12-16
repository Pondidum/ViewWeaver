using System;
using System.Collections.Generic;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.CheckSpecs
{
	namespace CollectionSpecs
	{
		public class When_passed_a_null_value : CheckSpecBase
		{
			Because of = () => ex = Catch.Exception(() => Check.Collection(null));
			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_a_non_null_value : CheckSpecBase
		{
			Establish context = () => collection = new List<string>() { "test", "two" };
			Because of = () => ex = Catch.Exception(() => Check.Collection(collection));
			It should_do_nothing = () => ex.ShouldBeNull();

			static List<string> collection;
		}
	}
}
