using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewWeaver.Helpers.GridPopulation
{
	internal class Configuration
	{
		public bool ClearOnPopulate { get; internal set; }

		internal Configuration()
		{
			ClearOnPopulate = true;
		}
	}

	internal sealed class Configuration<T> : Configuration
	{
		public IList<ColumnMapping<T>> ColumnMappings { get; internal set; }

		internal Configuration()
		{
			ColumnMappings = new List<ColumnMapping<T>>();
		}
	}
}