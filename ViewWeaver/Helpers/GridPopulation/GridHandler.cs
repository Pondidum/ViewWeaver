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

		public static void AddGridPopulator(Type type, IGridPopulator populator)
		{
			Handler.AddGridPopulator(type, populator);
		}

		public static void Populate<T>(Control grid, Configuration<T> config, IEnumerable<T> collection)
		{
			Handler.Populate(grid, config, collection);
		}

	}
}
