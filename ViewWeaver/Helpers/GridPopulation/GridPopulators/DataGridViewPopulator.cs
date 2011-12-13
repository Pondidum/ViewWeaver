using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ViewWeaver.Extensions;

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

		public void ClearColumns(Object grid)
		{
			var dgv = (DataGridView)grid;

			dgv.Columns.Clear();
		}

		public void AddColumn<T>(Object grid, ColumnMapping<T> mapping)
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

		public void ClearRows(Object grid)
		{
			var dgv = (DataGridView)grid;

			dgv.Rows.Clear();
		}

		public void AddRow(Object grid, Object rowData, IDictionary<int, Object> columnData)
		{
			var dgv = (DataGridView)grid;
			var row = new DataGridViewRow();
			row.CreateCells(dgv);

			columnData.ForEach(x => row.Cells[x.Key].Value = x.Value);
			
			row.Tag = rowData;

			dgv.Rows.Add(row);
		}

		public void BeginEdit(Object grid)
		{
			var dgv = (DataGridView)grid;
			dgv.SuspendLayout();
		}

		public void EndEdit(Object grid)
		{
			var dgv = (DataGridView)grid;
			dgv.ResumeLayout();
		}
	}
}
