using System;
using System.Collections.Generic;

namespace ViewWeaver.Helpers.GridPopulation
{
    public sealed class FluentConfiguration<T>
    {
        private bool _automaticColumns;
        private bool _createMissingColumns;
        private IDictionary<int, Func<T, Object>> _columns;

        internal FluentConfiguration()
        {
            _columns = new Dictionary<int, Func<T, object>>();
        }

        public FluentConfiguration<T> AutomaticColumns()
        {
            _automaticColumns = true;
            return this;
        }

        public FluentConfiguration<T> CreateMissingColumns()
        {
            _createMissingColumns = true;
            return this;
        }

        public FluentConfiguration<T> Columns(int index, Func<T, Object> creator)
        {
            return this;
        }

        internal Configuration<T> ToConfiguration()
        {
            if (_automaticColumns)
            {
                _columns.Clear();
                _columns = ColumnMapper.Map<T>();
            }

            return new Configuration<T>(_columns, _createMissingColumns);
        }

    }
}