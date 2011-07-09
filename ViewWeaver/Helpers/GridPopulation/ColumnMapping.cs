using System;

namespace ViewWeaver.Helpers.GridPopulation
{
	public class ColumnMapping
	{
		public int Index { get; set; }
		public String Name { get; set; }
		public String Title { get; set; }
		public Type DataType { get; set; }
	}

	internal class ColumnMapping<T> : ColumnMapping
	{
		public Func<T, Object> Populator { private get; set; }

		public Object Populate(T item)
		{
			return Populator.Invoke(item);
		}
	}
}
