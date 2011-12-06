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
		private readonly IDictionary<Control, Configuration> _grids;
		private readonly IDictionary<Type, IGridPopulator> _populators;

		internal GridHandlerImpl()
		{
			_grids = new Dictionary<Control, Configuration>();
			_populators = new Dictionary<Type, IGridPopulator>();
		}

		public void AddGridPopulator(Type gridType, IGridPopulator populator)
		{
			Check.Argument(gridType, "gridType");
			Check.Argument(populator, "populator");

			_populators.Add(gridType, populator);
		}

		public FluentConfiguration<T> Setup<T>(Control grid)
		{
			Check.Argument(grid, "grid");

			var config = new Configuration<T>();
			
			_grids[grid] = config;
			return new FluentConfiguration<T>(config);
		}

		public void Initialise<T>(Control grid)
		{
			Check.Argument(grid, "grid");

			var config = _grids[grid] as Configuration<T>;
			var populator = _populators[grid.GetType()];

			if (config == null)
			{
				config = new Configuration<T>();
				_grids[grid] = config;
			}

			Check.Configuration("There is no populator setup for grids of type '{0}'", grid.GetType().Name);

			populator.ClearColumns(grid);

			foreach (var mapping in config.ColumnMappings)
			{
				populator.AddColumn(grid, mapping);
			}
		}

		public void Populate<T>(Control grid, IEnumerable<T> collection)
		{
			Check.Argument(grid, "grid");

			var config = _grids[grid] as Configuration<T>;
			var populator = _populators[grid.GetType()];

			Check.Configuration("{0} has not been setup", grid.Name);
			Check.Configuration("There is no populator setup for grids of type '{0}'", grid.GetType().Name);

			try
			{
				populator.BeginEdit(grid);

				if (config.ClearOnPopulate)
				{
					populator.ClearRows(grid);
				}

				if (config.InitialiseOnPopulate || (config.InitialiseOnFirstPopulate && !config.HasBeenPopulated ))
				{
					Initialise<T>(grid);
				}

				foreach (var current in collection)
				{
					var maxColumn = config.ColumnMappings.Max(m => m.Index);
					var row = new object[maxColumn + 1];

					foreach (var mapping in config.ColumnMappings)
					{
						row[mapping.Index] = mapping.Populate(current);
					}

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
