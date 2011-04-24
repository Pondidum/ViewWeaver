using System.Linq;
using System.Windows.Forms;

namespace ViewWeaver.Helpers.GridPopulation.GridPopulators
{
    public class DataGridViewPopulator : IGridPopulator
    {
     
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
            row.SetValues(columnData.ToArray());
            row.Tag = rowData;

            dgv.Rows.Add(row);
        }

    }
}