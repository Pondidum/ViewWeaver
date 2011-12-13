using Machine.Specifications;
using ViewWeaver.Specs.TestData;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.EnumExtensionSpecs
{
	public class AddSpecs
	{
		public class AddSpecBase : SpecBase
		{
			protected static FlagsTest result;
			protected static FlagsTest input;
		}

		public class When_run_on_a_null_enum : AddSpecBase
		{
			Because of = () => result = default(FlagsTest).Add(FlagsTest.Two);
			It should_add_the_value_to_the_enum_default_value = () => result.ShouldEqual(FlagsTest.Two);
		}

		public class When_passed_a_null_value : AddSpecBase
		{
			Establish context = () => input = FlagsTest.One;
			Because of = () => result = input.Add(default(FlagsTest));
			It should_add_the_default_enum_value = () => result.ShouldEqual(FlagsTest.One);
		}

		public class When_adding_to_an_enum_with_the_value_in_already : AddSpecBase
		{
			Establish context = () => input = FlagsTest.Four;
			Because of = () => result = input.Add(FlagsTest.Four);
			It should_be_equal_to_the_original_value = () => result.ShouldEqual(FlagsTest.Four);
		}

		public class When_adding_to_a_multi_value_enum_without_the_value_already : AddSpecBase
		{
			Establish context = () => input = FlagsTest.Two | FlagsTest.Four;
			Because of = () => result = input.Add(FlagsTest.One);
			It should_add_the_value = () => result.ShouldEqual((FlagsTest)7);
		}

		public class When_adding_to_a_multi_value_enum_with_the_value_already : AddSpecBase
		{
			Establish context = () => input = FlagsTest.Two | FlagsTest.Four;
			Because of = () => result = input.Add(FlagsTest.Four);
			It should_not_add_the_value = () => result.ShouldEqual((FlagsTest)6);
		}

	}
}
