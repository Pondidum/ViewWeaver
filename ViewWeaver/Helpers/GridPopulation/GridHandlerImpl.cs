using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ViewWeaver.Extensions;

namespace ViewWeaver.Helpers.GridPopulation
{
	internal class GridHandlerImpl
	{
		private readonly IDictionary<Type, IGridPopulator> _populators;

		internal GridHandlerImpl()
		{
			_populators = new Dictionary<Type, IGridPopulator>();
		}

		public void AddPopulator(Type gridType, IGridPopulator populator)
		{
			Check.Argument(gridType, "gridType");
			Check.Argument(populator, "populator");

			_populators.Add(gridType, populator);
		}

		public void ConfigureColumns<T>(Control grid, ColumnMappingCollection<T> mapping)
		{
			Check.Argument(grid, "grid");
			Check.Argument(mapping, "mapping");

			var populator = _populators.GetOrDefault(grid.GetType());

			if (populator == null)
			{
				throw new MissingPopulatorException(String.Format("No populator has been registered for {0} grids.", grid.GetType()));
			}

			populator.ClearColumns(grid);

			foreach (var map in mapping)
			{
				populator.AddColumn(grid, map);
			}
		}

		public void Populate<T>(Control grid, ColumnMappingCollection<T> mappings, IEnumerable<T> collection)
		{
			Check.Argument(grid, "grid");
			Check.Argument(mappings, "mappings");
			Check.Argument(collection, "collection");

			var populator = _populators.GetOrDefault(grid.GetType());

			if (populator == null)
			{
				throw new MissingPopulatorException(String.Format("No populator has been registered for {0} grids.", grid.GetType()));
			}

			try
			{
				populator.BeginEdit(grid);
				
				foreach (var current in collection)
				{
					var item = current;
					var row = mappings.ToDictionary(x => x.Index, x => x.GetValueFrom(item));

					populator.AddRow(grid, current, row);
				}

			}
			finally
			{
				populator.EndEdit(grid);
			}

		}

	}
}
