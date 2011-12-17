using Machine.Specifications;
using ViewWeaver.Specs.Helpers.GridPopulation.FluentColumnMappingSpecs;

namespace ViewWeaver.Specs.Helpers.GridPopulation.ColumnMapperSpecs
{
	namespace PopulatedBySpecs
	{
		public class When_passed_a_value : FluentColumnMappingSpecBase
		{
			Because of = () => result = fluent.PopulatedBy(x => "test");

			It should_return_the_fluent_interface = () => result.ShouldEqual(fluent);
			It should_set_the_name_property = () => mapping.Populator.ShouldNotBeNull();
		}
	}
}
