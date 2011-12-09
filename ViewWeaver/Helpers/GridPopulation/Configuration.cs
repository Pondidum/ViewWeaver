using System.Collections.Generic;

namespace ViewWeaver.Helpers.GridPopulation
{
	public class Configuration
	{
		public bool ClearOnPopulate { get; internal set; }
		public bool InitialiseOnPopulate { get; internal set; }
		public bool InitialiseOnFirstPopulate { get; internal set; }
		internal bool HasBeenPopulated { get; set; }

		internal Configuration()
		{
			SetDefaults();
		}

		internal void SetDefaults()
		{
			ClearOnPopulate = true;
			InitialiseOnPopulate = false;
			InitialiseOnFirstPopulate = false;
			HasBeenPopulated = false;
		}
	}

	public sealed class Configuration<T> : Configuration
	{
		public IList<ColumnMapping<T>> ColumnMappings { get; internal set; }

		internal Configuration()
		{
			ColumnMappings = new List<ColumnMapping<T>>();
		}
	}
}