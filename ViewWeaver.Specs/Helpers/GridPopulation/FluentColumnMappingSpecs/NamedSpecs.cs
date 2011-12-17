using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;
using ViewWeaver.Specs.TestData.Classes;

namespace ViewWeaver.Specs.Helpers.GridPopulation.FluentColumnMappingSpecs
{
	namespace NamedSpecs
	{
		public class When_passed_a_value : FluentColumnMappingSpecBase
		{
			Because of = () => result = fluent.Named("testing");

			It should_return_the_fluent_interface = () => result.ShouldEqual(fluent);
			It should_set_the_name_property = () => mapping.Name.ShouldEqual("testing");
		}
	}
}
