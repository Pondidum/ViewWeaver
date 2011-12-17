using System;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;
using ViewWeaver.Specs.TestData.Classes;

namespace ViewWeaver.Specs.Helpers.GridPopulation.ColumnMapperSpecs
{
	namespace MapForTypeSpecs
	{

		public class When_passed_no_parameters : ColumnMapperSpecBase<OnePublicProperty>
		{
			Because of = () => mapping = ColumnMapper.ForType<OnePublicProperty>();

			It should_return_an_empty_collection = () => mapping.ShouldBeEmpty();
		}

		public class When_a_single_column_is_configured : ColumnMapperSpecBase<OnePublicProperty>
		{
			Because of = () => mapping = ColumnMapper.ForType<OnePublicProperty>(x => x.Named("Test"));

			It should_return_one_mapping = () => mapping.Count.ShouldEqual(1);
		}

		public class When_two_columns_are_configured : ColumnMapperSpecBase<OnePublicProperty>
		{
			Because of = () => mapping = ColumnMapper.ForType<OnePublicProperty>(x => x.Named("first"),
																				 x => x.Named("second"));

			It should_return_two_mappings = () => mapping.Count.ShouldEqual(2);
			It should_have_the_first_configuration_first = () => mapping.First().Name.ShouldEqual("first");
			It should_have_the_second_configuration_last = () => mapping.Last().Name.ShouldEqual("second");
		}
	}
}
