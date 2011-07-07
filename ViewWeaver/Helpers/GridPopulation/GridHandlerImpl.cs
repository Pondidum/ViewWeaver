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

        public void AddGridPopulator(Type type, IGridPopulator populator)
        {
            Check.Self(populator, "populator");
            _populators.Add(type, populator);
        }

        public FluentConfiguration<T> Setup<T>(Control grid)
        {
            Check.Self(grid, "grid");

            var config = new Configuration<T>();

            _grids[grid] = config;
            return new FluentConfiguration<T>(config);
        }

        public void Populate<T>(Control grid, IEnumerable collection)
        {
            Check.Self(grid, "grid");

            var config = _grids[grid] as Configuration<T>;
            var populator = _populators[grid.GetType()];

            if (config == null) throw new InvalidConfigurationException(string.Format("{0} has not been setup", grid.Name));
            if (populator == null) throw new InvalidConfigurationException(string.Format("There is no populator setup for grids of type '{0}'", grid.GetType().Name));

            if (config.ClearOnPopulate) populator.ClearRows(grid);

            var enumerator = (IEnumerator<T>)collection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                var row = config.ColumnMappings.Select(mapping => mapping.Value.Invoke(current));

                populator.AddRow(grid, current, row);
            }
        }
        
    }

}