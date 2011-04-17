using System;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions
{
    namespace EnumExtensionSpecs
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

        namespace Add
        {
            public class AddSpec : SpecBase
            {
                protected static FlagsTest result;
                protected static FlagsTest input;
            }

            public class When_run_on_a_null_enum : AddSpec
            {
                Because of = () => result = EnumExtensions.Add(default(FlagsTest), FlagsTest.Two);
                It should_add_the_value_to_the_enum_default_value = () => result.ShouldEqual(FlagsTest.Two);
            }

            public class When_passed_a_null_value : AddSpec
            {
                Establish context = () => input = FlagsTest.One;
                Because of = () => result = EnumExtensions.Add(input, default(FlagsTest));
                It should_add_the_default_enum_value = () => result.ShouldEqual(FlagsTest.One);
            }

            public class When_adding_to_an_enum_with_the_value_in_already : AddSpec
            {
                Establish context = () => input = FlagsTest.Four;
                Because of = () => result = EnumExtensions.Add(input, FlagsTest.Four);
                It should_be_equal_to_the_original_value = () => result.ShouldEqual(FlagsTest.Four);
            }

            public class When_adding_to_a_multi_value_enum_without_the_value_already : AddSpec
            {
                Establish context = () => input = FlagsTest.Two | FlagsTest.Four;
                Because of = () => result = EnumExtensions.Add(input, FlagsTest.One);
                It should_add_the_value = () => result.ShouldEqual((FlagsTest)7);
            }

            public class When_adding_to_a_multi_value_enum_with_the_value_already : AddSpec
            {
                Establish context = () => input = FlagsTest.Two | FlagsTest.Four;
                Because of = () => result = EnumExtensions.Add(input, FlagsTest.Four);
                It should_not_add_the_value = () => result.ShouldEqual((FlagsTest)6);
            }

        }

        namespace Remove
        {
            public class RemoveSpec : SpecBase
            {
                protected static FlagsTest result;
                protected static FlagsTest input;
            }

            public class When_passed_a_null_enum : RemoveSpec
            {
                Because of = () => result = EnumExtensions.Remove(default(FlagsTest), FlagsTest.Two);
                It should_return_the_default_value = () => result.ShouldEqual(FlagsTest.None);
            }

            public class When_passed_a_null_value : RemoveSpec
            {
                Establish context = () => input = FlagsTest.One;
                Because of = () => result = EnumExtensions.Remove(input, default(FlagsTest));
                It should_not_change_the_enum = () => result.ShouldEqual(input);
            }

            public class When_removing_from_an_enum_with_only_the_value : RemoveSpec
            {
                Establish context = () => input = FlagsTest.One;
                Because of = () => result = EnumExtensions.Remove(input, FlagsTest.One);
                It should_clear_the_enum = () => result.ShouldEqual(FlagsTest.None);
            }

            public class When_removing_from_an_enum_with_the_value_and_another_value : RemoveSpec
            {
                Establish context = () => input = FlagsTest.One | FlagsTest.Two;
                Because of = () => result = EnumExtensions.Remove(input, FlagsTest.One);
                It should_only_remove_the_specified_flag = () => result.ShouldEqual(FlagsTest.Two);
            }

            public class When_removing_from_an_enum_without_the_value : RemoveSpec
            {
                Establish context = () => input = FlagsTest.One;
                Because of = () => result = EnumExtensions.Remove(input, FlagsTest.Two);
                It should_not_change_the_enum = () => result.ShouldEqual(input);
            }

        }

        namespace Has
        {
            public class HasSpec : SpecBase
            {
                protected static FlagsTest flag;
                protected static bool result;
            }

            public class When_passed_a_null_enum : HasSpec
            {
                Establish context = () => flag = default(FlagsTest);
                Because of = () => result = EnumExtensions.Has(default(FlagsTest), FlagsTest.One);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_one_matching_value : HasSpec
            {
                Establish context = () => flag = FlagsTest.Two;
                Because of = () => result = EnumExtensions.Has(flag, FlagsTest.Two);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_one_non_matching_value : HasSpec
            {
                Establish context = () => flag = FlagsTest.Two;
                Because of = () => result = EnumExtensions.Has(flag, FlagsTest.Four);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_two_flags_set_and_a_matching_flag : HasSpec
            {
                Establish context = () => flag = FlagsTest.Two | FlagsTest.Four;
                Because of = () => result = EnumExtensions.Has(flag, FlagsTest.Two);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_two_flags_set_and_a_non_matching_flag : HasSpec
            {
                Establish context = () => flag = FlagsTest.Two | FlagsTest.Four;
                Because of = () => result = EnumExtensions.Has(flag, FlagsTest.Eight);
                It should_return_true = () => result.ShouldBeFalse();
            }
        }

        namespace HasAny
        {
            public class HasAnySpec : SpecBase
            {
                protected static FlagsTest flag;
                protected static bool result;
            }

            public class When_passed_an_enum_with_one_flag_and_one_matching_value : HasAnySpec
            {
                Establish context = () => flag = FlagsTest.Four;
                Because of = () => result = EnumExtensions.HasAny(flag, FlagsTest.Four);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_one_flag_and_one_non_matching_value : HasAnySpec
            {
                Establish context = () => flag = FlagsTest.Four;
                Because of = () => result = EnumExtensions.HasAny(flag, FlagsTest.Two);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_one_flag_and_a_matching_and_non_matching_value : HasAnySpec
            {
                Establish context = () => flag = FlagsTest.Four;
                Because of = () => result = EnumExtensions.HasAny(flag, FlagsTest.Four, FlagsTest.Two);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_two_flags_and_one_matching_value : HasAnySpec
            {
                Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
                Because of = () => result = EnumExtensions.HasAny(flag, FlagsTest.Four);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_two_flags_and_one_non_matching_value : HasAnySpec
            {
                Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
                Because of = () => result = EnumExtensions.HasAny(flag, FlagsTest.Eight);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_two_flags_and_a_matching_and_non_matching_value : HasAnySpec
            {
                Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
                Because of = () => result = EnumExtensions.HasAny(flag, FlagsTest.Four, FlagsTest.Eight);
                It should_return_true = () => result.ShouldBeTrue();
            }
        }

        namespace HasAll
        {
            public class HasAllSpec : SpecBase
            {
                protected static FlagsTest flag;
                protected static bool result;
            }

            public class When_passed_an_enum_with_one_flag_and_one_matching_value : HasAllSpec
            {
                Establish context = () => flag = FlagsTest.Four;
                Because of = () => result = EnumExtensions.HasAll(flag, FlagsTest.Four);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_one_flag_and_one_non_matching_value : HasAllSpec
            {
                Establish context = () => flag = FlagsTest.Four;
                Because of = () => result = EnumExtensions.HasAll(flag, FlagsTest.Two);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_one_flag_and_a_matching_and_non_matching_value : HasAllSpec
            {
                Establish context = () => flag = FlagsTest.Four;
                Because of = () => result = EnumExtensions.HasAll(flag, FlagsTest.Four, FlagsTest.Two);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_two_flags_and_one_matching_value : HasAllSpec
            {
                Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
                Because of = () => result = EnumExtensions.HasAll(flag, FlagsTest.Four);
                It should_return_true = () => result.ShouldBeTrue();
            }

            public class When_passed_an_enum_with_two_flags_and_one_non_matching_value : HasAllSpec
            {
                Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
                Because of = () => result = EnumExtensions.HasAll(flag, FlagsTest.Eight);
                It should_return_false = () => result.ShouldBeFalse();
            }

            public class When_passed_an_enum_with_two_flags_and_a_matching_and_non_matching_value : HasAllSpec
            {
                Establish context = () => flag = FlagsTest.Four | FlagsTest.Two;
                Because of = () => result = EnumExtensions.HasAll(flag, FlagsTest.Four, FlagsTest.Eight);
                It should_return_false = () => result.ShouldBeFalse();
            }
        }
    }
}
