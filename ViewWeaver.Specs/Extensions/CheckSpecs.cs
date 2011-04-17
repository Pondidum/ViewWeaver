using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using ViewWeaver.Extensions;

namespace ViewWeaver.Specs.Extensions
{
    namespace CheckSpecs
    {
        public class CheckSpec : SpecBase
        {

        }

        namespace Self
        {

            public class When_passed_a_null_value : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Self(null));
                It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
            }

            public class When_passed_a_non_null_value : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Self(new object()));
                It should_not_do_anything = () => ex.ShouldBeNull();
            }

        }

        namespace Collection
        {

            public class When_passed_a_null_value : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Collection(null));
                It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
            }

            public class When_passed_a_non_null_value : CheckSpec
            {
                Establish context = () => collection = new List<string>() { "test", "two" };
                Because of = () => ex = Catch.Exception(() => Check.Collection(collection));
                It should_do_nothing = () => ex.ShouldBeNull();

                static List<string> collection;
            }
        }

        namespace Enum
        {
            public  class When_passed_an_enum : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Enum(StringComparison.Ordinal));
                It should_should_do_nothing = () => ex.ShouldBeNull();
            }

            public class When_passed_a_structure : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Enum( new Test()));
                It should_throw_an_argument_exception = () => ex.ShouldBeOfType<ArgumentException>();
            }

            internal struct Test
            {
                public String Value;
            }
        }
    }
}