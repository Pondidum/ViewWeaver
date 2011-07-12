using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using ViewWeaver.Helpers.GridPopulation;

namespace ViewWeaver.Specs.Helpers.GridPopulation
{
	public class FluentConfigSpec<T> : SpecBase
	{
		protected static FluentConfiguration<T> fluent;
		internal static Configuration<T> config;

		public static void SetupConfiguration()
		{
			config = new Configuration<T>();
			fluent = new FluentConfiguration<T>(config);
		}
	}

	public class When_passed_a_null_configuration : FluentConfigSpec<int>
	{
		Because of = () => ex = Catch.Exception(() => fluent = new FluentConfiguration<int>(null));
		It should_throw_a_argument_null_exception = () => ex.ShouldBeOfType<ArgumentNullException>();
	}

	public class When_no_configuration_is_done : FluentConfigSpec<int>
	{
		Because of = () => SetupConfiguration();
		It should_set_clear_on_populate_to_false = () => config.ClearOnPopulate.ShouldBeFalse();
	}

	public class When_adding_a_column_mapping_manually : FluentConfigSpec<OnePublicProperty>
	{
		Establish context = () => SetupConfiguration();
		Because of = () => fluent.WithColumn(12, "name", "title", typeof (string), x => x.Test);
		It should_only_have_one_mapping = () => config.ColumnMappings.Count.ShouldEqual(1);
	}

}