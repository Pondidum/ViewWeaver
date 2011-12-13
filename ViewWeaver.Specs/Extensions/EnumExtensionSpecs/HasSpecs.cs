using Machine.Specifications;
using ViewWeaver.Specs.TestData;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions.EnumExtensionSpecs
{
	public class HasSpecs
	{
		public class HasSpecBase : SpecBase
		{
			protected static FlagsTest flag;
			protected static bool result;
		}

		public class When_passed_a_null_enum : HasSpecBase
		{
			Establish context = () => flag = default(FlagsTest);
			Because of = () => result = default(FlagsTest).Has(FlagsTest.One);
			It should_return_false = () => result.ShouldBeFalse();
		}

		public class When_passed_an_enum_with_one_matching_value : HasSpecBase
		{
			Establish context = () => flag = FlagsTest.Two;
			Because of = () => result = flag.Has(FlagsTest.Two);
			It should_return_true = () => result.ShouldBeTrue();
		}

		public class When_passed_an_enum_with_one_non_matching_value : HasSpecBase
		{
			Establish context = () => flag = FlagsTest.Two;
			Because of = () => result = flag.Has(FlagsTest.Four);
			It should_return_false = () => result.ShouldBeFalse();
		}

		public class When_passed_an_enum_with_two_flags_set_and_a_matching_flag : HasSpecBase
		{
			Establish context = () => flag = FlagsTest.Two | FlagsTest.Four;
			Because of = () => result = flag.Has(FlagsTest.Two);
			It should_return_true = () => result.ShouldBeTrue();
		}

		public class When_passed_an_enum_with_two_flags_set_and_a_non_matching_flag : HasSpecBase
		{
			Establish context = () => flag = FlagsTest.Two | FlagsTest.Four;
			Because of = () => result = flag.Has(FlagsTest.Eight);
			It should_return_true = () => result.ShouldBeFalse();
		}
	}
}
