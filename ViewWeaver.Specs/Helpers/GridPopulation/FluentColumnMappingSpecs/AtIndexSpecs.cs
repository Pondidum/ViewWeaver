using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;
using ViewWeaver.Specs.TestData.Classes;

namespace ViewWeaver.Specs.Helpers.GridPopulation.FluentColumnMappingSpecs
{
	namespace AtIndexSpecs
	{
		public class When_passed_a_value : FluentColumnMappingSpecBase
		{
			Because of = () => result = fluent.AtIndex(7);

			It should_return_the_fluent_interface = () => result.ShouldEqual(fluent);
			It should_set_the_name_property = () => mapping.Index.ShouldEqual(7);
		}
	}
}
