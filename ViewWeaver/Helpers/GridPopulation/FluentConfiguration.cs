using System;
using System.Collections.Generic;

namespace ViewWeaver.Helpers.GridPopulation
{
    public sealed class FluentConfiguration<T>
    {
        private readonly Configuration<T> _config;

        internal FluentConfiguration(Configuration<T> config)
        {
            _config = config;
        }

        public FluentConfiguration<T> AutomaticColumns()
        {
            _config.ColumnMappings = ColumnMapper.Map<T>();
            return this;
        }

        public FluentConfiguration<T> Columns(int index, Func<T, Object> creator)
        {
            _config.ColumnMappings.Add(index, creator);
            return this;
        }

        public FluentConfiguration<T> ClearOnPopulate()
        {
            _config.ClearOnPopulate = true;
            return this;
        }
    }
}