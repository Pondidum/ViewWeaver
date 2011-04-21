using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ViewWeaver.Extensions;

namespace ViewWeaver.Helpers.GridPopulation.GridPopulators
{
    public class DataGridViewPopulator : IGridPopulator
    {
        public void ClearColumns(object grid)
        {
            var dgv = (DataGridView)grid;

            dgv.Columns.Clear();
        }

        public void ClearRows(object grid)
        {
            var dgv = (DataGridView)grid;

            dgv.Rows.Clear();
        }

        public void AddColumn(object grid, string name, string caption, Type datatype, string format)
        {
            var dgv = (DataGridView)grid;

            dgv.Columns.Add(new DataGridViewColumn
                                {
                                    HeaderText = caption,
                                    Name = name,
                                    DefaultCellStyle = new DataGridViewCellStyle {Format = format}
                                });

        }

        public void AddRow(object grid, object rowData, params object[] columnData)
        {
            var dgv = (DataGridView)grid;

            var row = new DataGridViewRow();
            row.SetValues(columnData);
            row.Tag = rowData;

            dgv.Rows.Add(row);
        }

    }
}