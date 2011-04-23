using System;
using System.Collections.Generic;
using System.Linq;

namespace ViewWeaver.Helpers.GridPopulation
{
    internal class Configuration
    {
        public bool ClearOnPopulate { get; internal set; }

        internal Configuration()
        {
            ClearOnPopulate = true;
        }
    }

    internal sealed class Configuration<T> : Configuration
    {
        public IDictionary<int, Func<T, Object>> ColumnMappings { get; internal set; }

        internal Configuration() : base()
        {
            ColumnMappings = new Dictionary<int, Func<T, object>>();
        }
    }
}