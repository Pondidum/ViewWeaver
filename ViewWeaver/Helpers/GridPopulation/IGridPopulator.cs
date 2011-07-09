namespace ViewWeaver.Helpers.GridPopulation
{
	public interface IGridPopulator
	{
		void ClearColumns(object grid);
		void AddColumn(object grid, ColumnMapping mapping);

		void ClearRows(object grid);
		void AddRow(object grid, object rowData, params object[] columnData);

		void BeginEdit(object grid);
		void EndEdit(object grid);
	}
}
