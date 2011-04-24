using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ViewWeaver.Helpers.GridPopulation
{
    public class GridHandler
    {
        private static readonly GridHandlerImpl _handler;

        static GridHandler()
        {
            _handler = new GridHandlerImpl();
        }

         public static void AddGridPopulator(Type type, IGridPopulator populator)
         {
             _handler.AddGridPopulator(type, populator);
         }

         public static FluentConfiguration<T> Setup<T>(Control grid)
         {
             return _handler.Setup<T>(grid);
         }

         public static void Populate<T>(Control grid, IEnumerable<T> collection)
         {
             _handler.Populate(grid, collection);
         }

    }
}