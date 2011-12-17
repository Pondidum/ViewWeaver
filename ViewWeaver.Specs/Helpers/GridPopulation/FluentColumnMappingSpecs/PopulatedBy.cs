using Machine.Specifications;

namespace ViewWeaver.Specs.Helpers.GridPopulation.FluentColumnMappingSpecs
{
	namespace PopulatedBy
	{
		public class When_passed_a_value : FluentColumnMappingSpecBase
		{
			Because of = () => result = fluent.PopulatedBy(x => "test");

			It should_return_the_fluent_interface = () => result.ShouldEqual(fluent);
			It should_set_the_name_property = () => mapping.Populator.ShouldNotBeNull();
		}
	}
}
