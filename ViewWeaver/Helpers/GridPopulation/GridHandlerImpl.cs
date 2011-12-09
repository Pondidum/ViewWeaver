using System;
using System.Collections;
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

		public void AddGridPopulator(Type gridType, IGridPopulator populator)
		{
			Check.Argument(gridType, "gridType");
			Check.Argument(populator, "populator");

			_populators.Add(gridType, populator);
		}
		/*
				public FluentConfiguration<T> Setup<T>(Control grid)
				{
					Check.Argument(grid, "grid");

					var config = new Configuration<T>();
			
					_grids[grid] = config;
					return new FluentConfiguration<T>(config);
				}
		*/
		public void Populate<T>(Control grid, Configuration<T> config, IEnumerable<T> collection)
		{
			Check.Argument(grid, "grid");
			Check.Argument(config, "config");
			Check.Argument(collection, "collection");

			var populator = _populators.GetOrDefault(grid.GetType());

			if (populator == null)
			{
				throw new MissingPopulatorException();
			}

			try
			{
				populator.BeginEdit(grid);

				if (config.ClearOnPopulate)
				{
					populator.ClearRows(grid);
				}

				if (config.InitialiseOnPopulate || (config.InitialiseOnFirstPopulate && !config.HasBeenPopulated))
				{
					populator.ClearColumns(grid);
					config.ColumnMappings.ForEach(m => populator.AddColumn(grid, m));
				}
				
				foreach (var current in collection)
				{
					var item = current;
					var row = config.ColumnMappings.ToDictionary(x => x.Index, x => x.GetValueFrom(item));

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
