using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Machine.Specifications;
using Moq;
using ViewWeaver.Helpers.GridPopulation;
using It = Machine.Specifications.It;

namespace ViewWeaver.Specs.Helpers.GridPopulation
{
	public class GridHandlerImplSpec : SpecBase
	{
		internal static GridHandlerImpl handler;
	}

	public class When_adding_grid_populator_is_passed_a_null_populator : GridHandlerImplSpec
	{
		Establish context = () => handler = new GridHandlerImpl();
		Because of = () => ex = Catch.Exception(() => handler.AddPopulator(typeof(String), null));

		It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
	}

	public class When_adding_grid_populator_is_passed_a_null_type : GridHandlerImplSpec
	{
		Establish context = () => handler = new GridHandlerImpl();
		Because of = () => ex = Catch.Exception(() => handler.AddPopulator(null, Mock.Of<IGridPopulator>()));

		It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
	}

	public class When_populate_is_passed_a_null_grid : GridHandlerImplSpec
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

	public class When_populate_is_passed_a_null_configuration : GridHandlerImplSpec
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

	public class When_populate_is_passed_a_null_collection : GridHandlerImplSpec
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

}
