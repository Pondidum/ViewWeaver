using System;
using System.Collections.Generic;

namespace ViewWeaver.Helpers.GridPopulation
{
	public interface IGridPopulator
	{
		void ClearColumns(Object grid);
		void AddColumn<T>(Object grid, ColumnMapping<T> mapping);

		void ClearRows(Object grid);
		void AddRow(Object grid, Object rowData, IDictionary<int, Object> columnData);

		void BeginEdit(Object grid);
		void EndEdit(Object grid);
	}
}
