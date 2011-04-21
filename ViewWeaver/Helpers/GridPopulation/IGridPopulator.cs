using System;

namespace ViewWeaver.Helpers.GridPopulation
{
    public interface IGridPopulator
    {
        void ClearColumns(object grid);
        void ClearRows(object grid);

        void AddColumn(object grid, string name, string caption, Type dataType, string format);
        void AddRow(object grid, object rowData, params object[] columnData);
    }
}