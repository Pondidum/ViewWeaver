using System;

namespace ViewWeaver.Helpers.GridPopulation
{
	public class FluentColumnMapping<T>
	{
		private readonly ColumnMapping<T> _mapping;

		public FluentColumnMapping(ColumnMapping<T> mapping)
		{
			_mapping = mapping;
		}

		public FluentColumnMapping<T> Named(String name)
		{
			_mapping.Name = name;
			return this;
		}

		public FluentColumnMapping<T> AtIndex(int index)
		{
			_mapping.Index = index;
			return this;
		}

		public FluentColumnMapping<T> PopulatedBy(Func<T, Object> populator )
		{
			_mapping.Populator = populator;
			return this;
		}

		public FluentColumnMapping<T> Titled(String title)
		{
			_mapping.Title = title;
			return this;
		}

		public FluentColumnMapping<T> IsTyped(Type type)
		{
			_mapping.DataType = type;
			return this;
		}
	}
}
