using Machine.Specifications;
using ViewWeaver.Specs.TestData;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.EnumExtensions
{
	class RemoveSpecs
	{
		public class RemoveSpecBase : SpecBase
		{
			protected static FlagsTest result;
			protected static FlagsTest input;
		}

		public class When_passed_a_null_enum : RemoveSpecBase
		{
			Because of = () => result = default(FlagsTest).Remove(FlagsTest.Two);
			It should_return_the_default_value = () => result.ShouldEqual(FlagsTest.None);
		}

		public class When_passed_a_null_value : RemoveSpecBase
		{
			Establish context = () => input = FlagsTest.One;
			Because of = () => result = input.Remove(default(FlagsTest));
			It should_not_change_the_enum = () => result.ShouldEqual(input);
		}

		public class When_removing_from_an_enum_with_only_the_value : RemoveSpecBase
		{
			Establish context = () => input = FlagsTest.One;
			Because of = () => result = input.Remove(FlagsTest.One);
			It should_clear_the_enum = () => result.ShouldEqual(FlagsTest.None);
		}

		public class When_removing_from_an_enum_with_the_value_and_another_value : RemoveSpecBase
		{
			Establish context = () => input = FlagsTest.One | FlagsTest.Two;
			Because of = () => result = input.Remove(FlagsTest.One);
			It should_only_remove_the_specified_flag = () => result.ShouldEqual(FlagsTest.Two);
		}

		public class When_removing_from_an_enum_without_the_value : RemoveSpecBase
		{
			Establish context = () => input = FlagsTest.One;
			Because of = () => result = input.Remove(FlagsTest.Two);
			It should_not_change_the_enum = () => result.ShouldEqual(input);
		}

	}
}
