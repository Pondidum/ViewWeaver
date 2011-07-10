using System;
using System.Drawing;
using System.Windows.Forms;

namespace ViewWeaver.Helpers.GridPopulation.GridPopulators
{
	public class DataGridViewPopulator : IGridPopulator
	{
		private static readonly Cache<Type, Func<DataGridViewCell>> CellTypeMap;

		static DataGridViewPopulator()
		{
			CellTypeMap = new Cache<Type, Func<DataGridViewCell>>();
			CellTypeMap.OnMissing = type => () => new DataGridViewTextBoxCell();

			CellTypeMap[typeof(Boolean)] = () => new DataGridViewCheckBoxCell();
			CellTypeMap[typeof(String)] = () => new DataGridViewTextBoxCell();
			CellTypeMap[typeof(Image)] = () => new DataGridViewImageCell();
			CellTypeMap[typeof(Enum)] = () => new DataGridViewComboBoxCell();
		}

		public void ClearColumns(object grid)
		{
			var dgv = (DataGridView)grid;

			dgv.Columns.Clear();
		}

		public void AddColumn(object grid, ColumnMapping mapping)
		{
			var dgv = (DataGridView)grid;

			var column = new DataGridViewColumn
							{
								DisplayIndex = mapping.Index,
								Name = mapping.Name,
								HeaderText = mapping.Title,
								ValueType = mapping.DataType,
								CellTemplate = CellTypeMap[mapping.DataType].Invoke(),
							};

			dgv.Columns.Add(column);
		}

		public void ClearRows(object grid)
		{
			var dgv = (DataGridView)grid;

			dgv.Rows.Clear();
		}

		public void AddRow(object grid, object rowData, params object[] columnData)
		{
			var dgv = (DataGridView)grid;

			var row = new DataGridViewRow();
			row.CreateCells(dgv);
			row.SetValues(columnData);
			
			row.Tag = rowData;

			dgv.Rows.Add(row);
		}

		public void BeginEdit(object grid)
		{
			var dgv = (DataGridView)grid;
			dgv.SuspendLayout();
		}

		public void EndEdit(object grid)
		{
			var dgv = (DataGridView)grid;
			dgv.ResumeLayout();
		}
	}
}
