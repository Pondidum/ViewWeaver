using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;

namespace ViewWeaver.Specs.Helpers.GridPopulation
{

	public class ColumMapperSpec<T> : SpecBase
	{
		protected static IList<ColumnMapping<T>> mapping;
	}

	public class When_passed_a_type_with_no_members : ColumMapperSpec<NoMembers>
	{
		Because of = () => mapping =  ColumnMapper.Map<NoMembers>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_private_property : ColumMapperSpec<OnePrivateProperty>
	{
		Because of = () => mapping = ColumnMapper.Map<OnePrivateProperty>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_public_method : ColumMapperSpec<OnePublicMethod>
	{
		Because of = () => mapping = ColumnMapper.Map<OnePublicMethod>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_public_write_only_property : ColumMapperSpec<OnePublicWriteonlyProperty>
	{
		Because of = () => mapping = ColumnMapper.Map<OnePublicWriteonlyProperty>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_public_readonly_property : ColumMapperSpec<OnePublicReadonlyProperty>
	{
		Because of = () => mapping = ColumnMapper.Map<OnePublicReadonlyProperty>();
		It should_return_one_mapping = () => mapping.Count.ShouldEqual(1);
		It should_have_an_index_of_zero = () => mapping.First().Index.ShouldEqual(0);
		It should_get_property_return_type = () => mapping.First().DataType.ShouldEqual(typeof (String));
		It should_be_named_after_the_property = () => mapping.First().Name.ShouldEqual("Test");
	}


	public class NoMembers {}
	public class OnePrivateProperty { private String Test { get; set; } }
	public class OnePublicWriteonlyProperty { public String Test { private get; set; } }
	public class OnePublicReadonlyProperty { public String Test { get; private set; } }
	public class OnePublicProperty { public String Test { get; set; } }
	public class OnePublicMethod { public String Test() { return "value"; } }


}