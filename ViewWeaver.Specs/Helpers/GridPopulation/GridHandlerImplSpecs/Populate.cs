using System;
using System.Linq;
using System.Windows.Forms;
using Machine.Specifications;
using Moq;
using ViewWeaver.Helpers.GridPopulation;
using It = Machine.Specifications.It;

namespace ViewWeaver.Specs.Helpers.GridPopulation.GridHandlerImplSpecs
{
	namespace Populate
	{
		public class PopulateSpecBase :GridHandlerImplSpecBase
		{
			Establish context = () =>
			{
				handler = new GridHandlerImpl();
				handler.AddPopulator(typeof(Control), Mock.Of<IGridPopulator>());
			};
		}

		public class When_populate_is_passed_a_null_grid : PopulateSpecBase
		{
			Because of = () => ex = Catch.Exception(() => handler.Populate(null,
																		   Mock.Of<ColumnMappingCollection<String>>(),
																		   Enumerable.Empty<String>()));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_populate_is_passed_a_null_configuration : PopulateSpecBase
		{
			Because of = () => ex = Catch.Exception(() => handler.Populate(new Control(),
																		   null,
																		   Enumerable.Empty<String>()));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_populate_is_passed_a_null_collection : PopulateSpecBase
		{
			Because of = () => ex = Catch.Exception(() => handler.Populate(new Control(),
																		   Mock.Of<ColumnMappingCollection<String>>(),
																		   null));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}
	}
}
