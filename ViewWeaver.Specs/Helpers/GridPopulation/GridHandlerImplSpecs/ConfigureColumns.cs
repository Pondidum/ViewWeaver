using System;
using System.Windows.Forms;
using Machine.Specifications;
using Moq;
using ViewWeaver.Helpers.GridPopulation;
using It = Machine.Specifications.It;
using Arg = Moq.It;

namespace ViewWeaver.Specs.Helpers.GridPopulation.GridHandlerImplSpecs
{
	namespace ConfigureColumns
	{
		public class ConfigureColumnsSpecBase : GridHandlerImplSpecBase
		{
			protected static Mock<IGridPopulator> populator;
			protected static ColumnMappingCollection<String> mapping;
			protected static Control grid;


			Establish context = () =>
			{
				populator = new Mock<IGridPopulator>();

				handler = new GridHandlerImpl();
				handler.AddPopulator(typeof(Control), populator.Object);

				mapping = Mock.Of<ColumnMappingCollection<String>>();
				grid = new Control();
			};
		}

		public class When_passed_a_null_grid : ConfigureColumnsSpecBase
		{
			Because of = () => ex = Catch.Exception(() => handler.ConfigureColumns(null, mapping));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_a_null_mapping : ConfigureColumnsSpecBase
		{
			Because of = () => ex = Catch.Exception(() => handler.ConfigureColumns<String>(grid, null));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_called_for_a_grid_without_a_populator : GridHandlerImplSpecBase
		{
			Establish context = () => handler = new GridHandlerImpl();
			Because of = () => ex = Catch.Exception(() => handler.ConfigureColumns(new Control(), Mock.Of<ColumnMappingCollection<String>>()));

			It should_throw_a_missing_populator_exception = () => ex.ShouldBeOfType<MissingPopulatorException>();
		}

		public class When_passed_an_empty_mapping : ConfigureColumnsSpecBase
		{
			Because of = () => handler.ConfigureColumns(grid, mapping);

			It should_call_clear_columns = () => populator.Verify(x => x.ClearColumns(Arg.IsAny<Control>()), 
																  Times.Once());

			It should_not_call_add_column = () => populator.Verify(x => x.AddColumn(Arg.IsAny<Control>(), Arg.IsAny<ColumnMapping<String>>()), 
																   Times.Never());
		}

		public class When_passed_a_single_mapping : ConfigureColumnsSpecBase
		{
			Establish context = () => mapping.Add(new ColumnMapping<String>());
			Because of = () => handler.ConfigureColumns(grid, mapping);

			It should_call_add_column_once = () => populator.Verify(x => x.AddColumn(Arg.IsAny<Control>(), 
																					 Arg.IsAny<ColumnMapping<String>>()), 
																   Times.Once());
		}
	}
}
