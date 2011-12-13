using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;

namespace ViewWeaver.Specs.Helpers.GridPopulation
{

	public class ColumnMapperSpec<T> : SpecBase
	{
		protected static IList<ColumnMapping<T>> mapping;
	}

	public class When_passed_a_type_with_no_members : ColumnMapperSpec<NoMembers>
	{
		Because of = () => mapping =  ColumnMapper.AutomapForType<NoMembers>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_private_property : ColumnMapperSpec<OnePrivateProperty>
	{
		Because of = () => mapping = ColumnMapper.AutomapForType<OnePrivateProperty>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_public_method : ColumnMapperSpec<OnePublicMethod>
	{
		Because of = () => mapping = ColumnMapper.AutomapForType<OnePublicMethod>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_public_write_only_property : ColumnMapperSpec<OnePublicWriteonlyProperty>
	{
		Because of = () => mapping = ColumnMapper.AutomapForType<OnePublicWriteonlyProperty>();
		It should_return_no_mappings = () => mapping.ShouldBeEmpty();
	}

	public class When_passed_a_type_with_one_public_readonly_property : ColumnMapperSpec<OnePublicReadonlyProperty>
	{
		Because of = () => mapping = ColumnMapper.AutomapForType<OnePublicReadonlyProperty>();

		It should_return_one_mapping = () => mapping.Count.ShouldEqual(1);
		It should_have_an_index_of_zero = () => mapping.First().Index.ShouldEqual(0);
		It should_get_property_return_type = () => mapping.First().DataType.ShouldEqual(typeof (String));
		It should_be_named_after_the_property = () => mapping.First().Name.ShouldEqual("Test");
		It should_return_the_property_value = () => mapping.First().GetValueFrom(new OnePublicReadonlyProperty("omg")).ShouldEqual("omg");
	}

	public class When_passed_a_type_with_two_public_readonly_properties : ColumnMapperSpec<TwoPublicReadonlyProperties>
	{
		Because of = () => mapping = ColumnMapper.AutomapForType<TwoPublicReadonlyProperties>();
		It should_return_two_mappings = () => mapping.Count.ShouldEqual(2);
	}


	public class NoMembers {}
	
	public class OnePrivateProperty
	{
		private String Test { get; set; }
	}
	
	public class OnePublicWriteonlyProperty
	{
		public String Test { private get; set; }
	}
	
	public class OnePublicReadonlyProperty
	{
		public OnePublicReadonlyProperty(String value) { Test = value; }
		public String Test { get; private set; }
	}
	
	public class OnePublicProperty
	{
		public String Test { get; set; }
	}
	
	public class OnePublicMethod
	{
		public String Test() { return "value"; }
	}

	public class TwoPublicReadonlyProperties 
	{
		public String FirstProperty { get; private set; }
		public int SecondProperty { get; private set; }
	}

}
