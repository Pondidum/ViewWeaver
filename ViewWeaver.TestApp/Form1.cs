using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ViewWeaver.Helpers.GridPopulation;
using ViewWeaver.Helpers.GridPopulation.GridPopulators;

namespace ViewWeaver.TestApp
{
	public partial class Form1 : Form
	{
		private ColumnMappingCollection<Product> _mapping;

		public Form1()
		{
			InitializeComponent();
			_mapping = ColumnMapper.AutomapForType<Product>();
			_mapping = ColumnMapper.ForType<Product>(x => x.Named("test").AtIndex(3));
		}

		private void btnRegister_Click(object sender, EventArgs e)
		{
			GridHandler.AddPopulator(typeof(DataGridView), new DataGridViewPopulator());
		}

		private void btnSetupColumns_Click(object sender, EventArgs e)
		{
			GridHandler.ConfigureColumns(dgv, _mapping);
		}

		private void btnPopulate_Click(object sender, EventArgs e)
		{
			//var m2 = ColumnMapper.For<Product>().DefineColumn(new ColumnMapping<Product>());

			//var config = GridHandler.CreateConfiguration<Product>(c => c.WithColumn(0, "Name", "Name", typeof(String), x => x.Name));

			var collection = new List<Product>();
			collection.Add(new Product());

			GridHandler.Populate(dgv, _mapping, collection);
		}

	}

	public class Product
	{
		public String Name { get; set; }

		public Product()
		{
			Name = Guid.NewGuid().ToString();
		}
	}
}
