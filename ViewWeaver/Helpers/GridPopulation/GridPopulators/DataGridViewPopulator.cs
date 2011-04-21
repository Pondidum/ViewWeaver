using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void AddColumn(object grid, string name, string caption, Type dataType, string format)
        {
            var dgv = (DataGridView)grid;

            dgv.Columns.Add(new DataGridViewColumn
                                {
                                    HeaderText = caption,
                                    Name = name,
                                    CellTemplate = CellTemplateFromDataType(dataType),
                                    DefaultCellStyle = new DataGridViewCellStyle { Format = format }
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

        private DataGridViewCell CellTemplateFromDataType(Type type)
        {
            if (type.IsSubclassOf(typeof(DataGridViewCell)))
            {
                return (DataGridViewCell)Activator.CreateInstance(type);
            }

            if (type == typeof(bool))
                return new DataGridViewCheckBoxCell();

            if (type.IsEnum)
                return new DataGridViewComboBoxCell();

            if (type.IsSubclassOf(typeof(Image)))
                return new DataGridViewImageCell();

            return new DataGridViewTextBoxCell();

        }
    }
}