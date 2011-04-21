using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewWeaver.Helpers.GridPopulation
{
    internal sealed class Configuration<T>
    {
        private IDictionary<int, Func<T, Object>> _columnMappings;

        public IDictionary<int, Func<T, Object>> ColumnMappings
        {
            get { return _columnMappings.ToDictionary(d => d.Key, d=> d.Value ); }
            private set { _columnMappings = value; }
        }
        public bool CreateMissingColumns { get; private set; }

        internal Configuration(IDictionary<int, Func<T, Object>> columnMappings, bool createMissingColumns)
        {
            ColumnMappings = columnMappings;
            CreateMissingColumns = createMissingColumns;
        }
    }
}