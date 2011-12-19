using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Machine.Specifications;
using Moq;
using ViewWeaver.Helpers.GridPopulation;
using ViewWeaver.Specs.TestData.Collections;
using It = Machine.Specifications.It;
using Arg = Moq.It;

namespace ViewWeaver.Specs.Helpers.GridPopulation.GridHandlerImplSpecs
{
	namespace Populate
	{
		public class When_passed_a_null_grid : GridHandlerImplSpecBase
		{
			Establish context = () =>
			{
				handler = new GridHandlerImpl();
				handler.AddPopulator(typeof(Control), Mock.Of<IGridPopulator>());
			};

			Because of = () => ex = Catch.Exception(() => handler.Populate(null,
																		   Mock.Of<ColumnMappingCollection<String>>(),
																		   Enumerable.Empty<String>()));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_a_null_mapping : GridHandlerImplSpecBase
		{
			Establish context = () =>
			{
				handler = new GridHandlerImpl();
				handler.AddPopulator(typeof(Control), Mock.Of<IGridPopulator>());
			};

			Because of = () => ex = Catch.Exception(() => handler.Populate(new Control(),
																		   null,
																		   Enumerable.Empty<String>()));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_passed_a_null_collection : GridHandlerImplSpecBase
		{
			Establish context = () =>
			{
				handler = new GridHandlerImpl();
				handler.AddPopulator(typeof(Control), Mock.Of<IGridPopulator>());
			};

			Because of = () => ex = Catch.Exception(() => handler.Populate(new Control(),
																		   Mock.Of<ColumnMappingCollection<String>>(),
																		   null));

			It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
		}

		public class When_called_for_a_grid_without_a_populator : GridHandlerImplSpecBase
		{
			Establish context = () => handler = new GridHandlerImpl();
			Because of = () => ex = Catch.Exception(() => handler.Populate(new Control(),
																		   Mock.Of<ColumnMappingCollection<String>>(),
																		   Enumerable.Empty<String>()));

			It should_throw_a_missing_populator_exception = () => ex.ShouldBeOfType<MissingPopulatorException>();
		}

		public class PopulatorSpecBase : GridHandlerImplSpecBase
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

		public class When_called_with_an_empty_collection : PopulatorSpecBase
		{
			Because of = () => handler.Populate(grid, mapping, Enumerable.Empty<String>());

			It should_call_begin_edit = () => populator.Verify(x => x.BeginEdit(grid), Times.Once());
			It should_call_end_edit = () => populator.Verify(x => x.EndEdit(grid), Times.Once());
		}

		public class When_called_with_a_throwing_collection : PopulatorSpecBase
		{
			Because of = () => ex = Catch.Exception(() => handler.Populate(grid, mapping, new ThrowingEnumerable<String>()));

			It should_throw_a_not_supported_exception = () => ex.ShouldBeOfType<NotSupportedException>();
			It should_call_begin_edit = () => populator.Verify(x => x.BeginEdit(grid), Times.Once());
			It should_call_end_edit = () => populator.Verify(x => x.EndEdit(grid), Times.Once());
		}

		public class When_called_with_no_mappings_and_a_single_item_collection : PopulatorSpecBase
		{
			Because of = () => handler.Populate(grid, mapping, new List<String> { "First" });

			It should_call_add_row_once = () => populator.Verify(x => x.AddRow(Arg.IsAny<Control>(),
																			   Arg.IsAny<Object>(),
																			   Arg.IsAny<IDictionary<int, Object>>()),
																 Times.Once());

			It should_call_with_values = () => populator.Verify(x => x.AddRow(Arg.IsAny<Control>(),
																			  Arg.Is<Object>(a => (String)a == "First"),
																			  Arg.Is<IDictionary<int, Object>>(a => a.Count == 0)),
																Times.Once());
		}

		public class When_called_with_a_mapping_and_a_single_item_collection : PopulatorSpecBase
		{
			Because of = () =>
			{
				mapping.Add(new ColumnMapping<String> { Populator = s => "Testing" });
				handler.Populate(grid, mapping, new List<String> { "First" });

			};

			It should_call_add_row_once = () => populator.Verify(x => x.AddRow(Arg.IsAny<Control>(),
																			   Arg.IsAny<Object>(),
																			   Arg.IsAny<IDictionary<int, Object>>()),
																 Times.Once());

			It should_call_with_one_value = () => populator.Verify(x => x.AddRow(Arg.IsAny<Control>(),
																				 Arg.Is<Object>(a => (String)a == "First"),
																				 Arg.Is<IDictionary<int, Object>>(a => (String)a.Single().Value == "Testing")));

		}

	}
}
