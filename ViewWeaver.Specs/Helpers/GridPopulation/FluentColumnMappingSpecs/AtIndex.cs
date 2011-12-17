using Machine.Specifications;

namespace ViewWeaver.Specs.Helpers.GridPopulation.FluentColumnMappingSpecs
{
	namespace AtIndex
	{
		public class When_passed_a_value : FluentColumnMappingSpecBase
		{
			Because of = () => result = fluent.AtIndex(7);

			It should_return_the_fluent_interface = () => result.ShouldEqual(fluent);
			It should_set_the_name_property = () => mapping.Index.ShouldEqual(7);
		}
	}
}
