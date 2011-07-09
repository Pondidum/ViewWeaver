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

		public static FluentConfiguration<T> Setup<T>(Control grid)
		{
			return Handler.Setup<T>(grid);
		}


		public static void Initialise<T>(Control grid)
		{
			Handler.Initialise<T>(grid);
		}

		public static void Populate<T>(Control grid, IEnumerable<T> collection)
		{
			Handler.Populate<T>(grid, collection);
		}

	}
}