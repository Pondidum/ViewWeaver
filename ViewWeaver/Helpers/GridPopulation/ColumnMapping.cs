using System;

namespace ViewWeaver.Helpers.GridPopulation
{
	public class ColumnMapping<T>
	{
		public int Index { get; set; }
		public String Name { get; set; }
		public String Title { get; set; }
		public Type DataType { get; set; }

		public Func<T, Object> Populator { private get; set; }

		public Object GetValueFrom(T item)
		{
			return Populator.Invoke(item);
		}

	}
}
