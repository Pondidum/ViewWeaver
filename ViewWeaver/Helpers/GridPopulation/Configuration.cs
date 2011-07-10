using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewWeaver.Helpers.GridPopulation
{
	internal class Configuration
	{
		public bool ClearOnPopulate { get; internal set; }
		public bool InitialiseOnPopulate { get; internal set; }
		public bool InitialiseOnFirstPopulate { get; internal set; }
		internal bool HasBeenPopulated { get; set; }

		internal Configuration()
		{
			SetDefaults();
		}

		public void SetDefaults()
		{
			ClearOnPopulate = true;
			InitialiseOnPopulate = false;
			InitialiseOnFirstPopulate = false;
			HasBeenPopulated = false;
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