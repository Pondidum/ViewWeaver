using System;
using System.Collections.Generic;

namespace ViewWeaver.Helpers.GridPopulation
{
	public interface IGridPopulator
	{
		void ClearColumns(Object grid);
		void AddColumn(Object grid, ColumnMapping mapping);

		void ClearRows(Object grid);
		void AddRow(Object grid, Object rowData, IDictionary<int, Object> columnData);

		void BeginEdit(Object grid);
		void EndEdit(Object grid);
	}
}
