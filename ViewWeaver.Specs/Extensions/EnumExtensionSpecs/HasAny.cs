using Machine.Specifications;
using ViewWeaver.Specs.TestData;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.EnumExtensionSpecs
{
	namespace HasAny
	{
		public class HasAnySpecBase : SpecBase
		{
			protected static FlagsTest flag;
			protected static bool result;
		}

		public class When_passed_an_enum_with_one_flag_and_one_matching_value : HasAnySpecBase
		{
			Establish context = () => flag = FlagsTest.Four;
			Because of = () => result = flag.HasAny(FlagsTest.Four);
			It should_return_true = () => result.ShouldBeTrue();
		}

		public class When_passed_an_enum_with_one_flag_and_one_non_matching_value : HasAnySpecBase
		{
			Establish context = () => flag = FlagsTest.Four;
			Because of = () => result = flag.HasAny(FlagsTest.Two);
			It should_return_false = () => result.ShouldBeFalse();
		}

		public class When_passed_an_enum_with_one_flag_and_a_matching_and_non_matching_value : HasAnySpecBase
		{
			Establish context = () => flag = FlagsTest.Four;
			Because of = () => result = flag.HasAny(FlagsTest.Four, FlagsTest.Two);
			It should_return_true = () => result.ShouldBeTrue();
		}

		public class When_passed_an_enum_with_two_flags_and_one_matching_value : HasAnySpecBase
		{
			Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
			Because of = () => result = flag.HasAny(FlagsTest.Four);
			It should_return_true = () => result.ShouldBeTrue();
		}

		public class When_passed_an_enum_with_two_flags_and_one_non_matching_value : HasAnySpecBase
		{
			Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
			Because of = () => result = flag.HasAny(FlagsTest.Eight);
			It should_return_false = () => result.ShouldBeFalse();
		}

		public class When_passed_an_enum_with_two_flags_and_a_matching_and_non_matching_value : HasAnySpecBase
		{
			Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
			Because of = () => result = flag.HasAny(FlagsTest.Four, FlagsTest.Eight);
			It should_return_true = () => result.ShouldBeTrue();
		}
	}
}
