using System;
using System.Collections.Generic;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.IDictionarySpecs
{
	namespace GetOrDefaultSpecs
	{
		public class GetOrDefaultSpecBase : SpecBase
		{
			protected static IDictionary<int, String> dictionary;
			protected static String result;
		}

		public class When_passed_a_null_dictionary : GetOrDefaultSpecBase
		{
			Establish context = () => dictionary = null;

			Because of = () => ex = Catch.Exception(() => dictionary.GetOrDefault(5));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType(typeof(ArgumentNullException));
		}

		public class When_passed_a_non_existant_key : GetOrDefaultSpecBase
		{
			Establish context = () =>
			{
				dictionary = new Dictionary<int, String>();
				dictionary.Add(1, "first");
				dictionary.Add(2, "second");
				dictionary.Add(3, "third");
			};

			Because of = () => result = dictionary.GetOrDefault(0);

			It should_return_the_default_value = () => result.ShouldEqual(default(String));
		}

		public class When_passed_an_existant_key : GetOrDefaultSpecBase
		{
			Establish context = () =>
			{
				dictionary = new Dictionary<int, String>();
				dictionary.Add(1, "first");
				dictionary.Add(2, "second");
				dictionary.Add(3, "third");
			};

			Because of = () => result = dictionary.GetOrDefault(2);

			It should_return_the_default_value = () => result.ShouldEqual("second");
		}

	}
}
