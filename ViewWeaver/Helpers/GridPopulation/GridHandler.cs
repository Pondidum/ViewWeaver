using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewWeaver.Helpers.GridPopulation
{
	public class GridHandler
	{
		private static readonly GridHandlerImpl Handler;

		static GridHandler()
		{
			Handler = new GridHandlerImpl();
		}

		public static void AddPopulator(Type type, IGridPopulator populator)
		{
			Handler.AddPopulator(type, populator);
		}

		public static void ConfigureColumns<T>(Control grid, ColumnMappingCollection<T> mapping)
		{
			Handler.ConfigureColumns(grid, mapping);
		}

		public static void Populate<T>(Control grid, ColumnMappingCollection<T> config, IEnumerable<T> collection)
		{
			Handler.Populate(grid, config, collection);
		}
		/*
		public static ColumnMappingCollection<T> CreateConfiguration<T>(params Action<FluentConfiguration<T>>[] columnOption)
		{
			var configuration = new ColumnMappingCollection<T>();

			foreach (var option in columnOption)
			{
				configuration.Add(option.Invoke(new FluentConfiguration<T>()));
			}
			configOptions.Invoke(new FluentConfiguration<T>(configuration));

			return configuration;
		}*/

	}
}
