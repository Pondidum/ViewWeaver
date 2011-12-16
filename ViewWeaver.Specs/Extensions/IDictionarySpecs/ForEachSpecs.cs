using System;
using System.Collections.Generic;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.IDictionarySpecs
{
	namespace ForEachSpecs
	{
		public class ForEachSpecBase : SpecBase
		{
			protected static IDictionary<int, String> dictionary;
			protected static IDictionary<int, String> loggedItems;

			protected static void LogItem(KeyValuePair<int, String> pair)
			{
				if (loggedItems == null) loggedItems = new Dictionary<int, String>();

				loggedItems.Add(pair);
			}
		}

		public class When_passed_a_null_dictionary : ForEachSpecBase
		{
			Establish context = () => dictionary = null;

			Because of = () => ex = Catch.Exception(() => dictionary.ForEach(x => LogItem(x)));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType(typeof(ArgumentNullException));
		}

		public class When_passed_a_null_action : ForEachSpecBase
		{
			Establish context = () => dictionary = new Dictionary<int, String>();

			Because of = () => ex = Catch.Exception(() => dictionary.ForEach(null));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType(typeof(ArgumentNullException));
		}

		public class When_passed_an_empty_dictionary : ForEachSpecBase
		{
			Establish context = () => dictionary = new Dictionary<int, String>();

			Because of = () => ex = Catch.Exception(() => dictionary.ForEach(x => LogItem(x)));

			It should_not_throw_an_exception = () => ex.ShouldBeNull();
		}

		public class When_passed_valid_arguments : ForEachSpecBase
		{
			Establish context = () =>
			{
				dictionary = new Dictionary<int, String>();
				dictionary.Add(1, "first");
				dictionary.Add(2, "second");
				dictionary.Add(3, "third");
			};

			Because of = () => ex = Catch.Exception(() => dictionary.ForEach(x => LogItem(x)));

			It should_log_each_item = () => loggedItems.ShouldContainOnly(dictionary);
		}

	}
}
