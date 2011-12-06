using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;

namespace ViewWeaver.Specs.Helpers.GridPopulation
{
	public class GridHandlerImplSpec : SpecBase
	{
		internal static GridHandlerImpl handler;
	}

	public class When_passed_a_null_grid : GridHandlerImplSpec
	{
		Establish context = () => handler = new GridHandlerImpl();
		Because of = () => handler.AddGridPopulator(typeof (String), null);
		It should_throw_an_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
	}

	public class When_passed_a_null_type : GridHandlerImplSpec
	{
		Establish context = () => handler = new GridHandlerImpl();
	}
	//public class When_populate_is_called_on_a_unconfigured_grid : GridHandlerImplSpec
	//{
		
	//}
}
