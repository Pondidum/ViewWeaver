using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;
using ViewWeaver.Specs.TestData.Classes;

namespace ViewWeaver.Specs.Helpers.GridPopulation.FluentColumnMappingSpecs
{
	public class FluentColumnMappingSpecBase : SpecBase
	{
		protected static ColumnMapping<OnePublicProperty> mapping;
		protected static FluentColumnMapping<OnePublicProperty> fluent;
		protected static FluentColumnMapping<OnePublicProperty> result;

		Establish context = () =>
		{
			mapping = new ColumnMapping<OnePublicProperty>();
			fluent = new FluentColumnMapping<OnePublicProperty>(mapping);
		};

	}
}