using System;

namespace ViewWeaver.Helpers.GridPopulation
{
    public interface IGridPopulator
    {
        void ClearRows(object grid);
        void AddRow(object grid, object rowData, params object[] columnData);
    }
}