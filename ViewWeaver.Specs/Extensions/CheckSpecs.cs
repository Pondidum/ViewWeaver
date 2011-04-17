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

            [Subject("Check.Self")]
            public class When_passed_a_null_value : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Self(null));
                It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject("Check.Self")]
            public class When_passed_a_non_null_value : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Self(new object()));
                It should_not_do_anything = () => ex.ShouldBeNull();
            }

        }

        namespace Collection
        {

            [Subject("Check.Collection")]
            public class When_passed_a_null_value : CheckSpec
            {
                Because of = () => ex = Catch.Exception(() => Check.Collection(null));
                It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
            }

            [Subject("")]
            public class When_passed_a_non_null_value : CheckSpec
            {
                Establish context = () => collection = new List<string>() { "test", "two" };
                Because of = () => ex = Catch.Exception(() => Check.Collection(collection));
                It should_not_do_anything = () => ex.ShouldBeNull();

                static List<string> collection;
            }
        }
    }
}