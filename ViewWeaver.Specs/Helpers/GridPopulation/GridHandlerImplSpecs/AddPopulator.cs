using System;
using Machine.Specifications;
using Moq;
using ViewWeaver.Helpers.GridPopulation;
using It = Machine.Specifications.It;

namespace ViewWeaver.Specs.Helpers.GridPopulation.GridHandlerImplSpecs
{
	namespace AddPopulator
	{
		public class When_adding_grid_populator_is_passed_a_null_populator : GridHandlerImplSpecBase
		{
			Establish context = () => handler = new GridHandlerImpl();
			Because of = () => ex = Catch.Exception(() => handler.AddPopulator(typeof(String), null));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_adding_grid_populator_is_passed_a_null_type : GridHandlerImplSpecBase
		{
			Establish context = () => handler = new GridHandlerImpl();
			Because of = () => ex = Catch.Exception(() => handler.AddPopulator(null, Mock.Of<IGridPopulator>()));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}
	}
}
