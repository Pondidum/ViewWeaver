using System;

namespace ViewWeaver.Helpers.GridPopulation
{
	public sealed class FluentConfiguration<T>
	{
		private readonly Configuration<T> _config;

		internal FluentConfiguration(Configuration<T> config)
		{
			if (config == null) throw new ArgumentNullException("config");

			_config = config;
			_config.ClearOnPopulate = false;
		}

		public FluentConfiguration<T> AutomaticColumns()
		{
			_config.ColumnMappings = ColumnMapper.Map<T>();
			return this;
		}

		public FluentConfiguration<T> WithColumn(int index, String name, String title, Type type, Func<T, Object> populator)
		{
			_config.ColumnMappings.Add(new ColumnMapping<T>
										{
											Index = index,
											Name = name,
											Title = title,
											DataType = type,
											Populator = populator
										});
			return this;
		}

		public FluentConfiguration<T> ClearOnPopulate()
		{
			_config.ClearOnPopulate = true;
			return this;
		}

		public FluentConfiguration<T> InitialiseOnPopulate()
		{
			_config.InitialiseOnPopulate = true;
			return this;
		}

		public FluentConfiguration<T> InitialiseOnFirstPopulate()
		{
			_config.InitialiseOnFirstPopulate = true;
			return this;
		}

	}
}