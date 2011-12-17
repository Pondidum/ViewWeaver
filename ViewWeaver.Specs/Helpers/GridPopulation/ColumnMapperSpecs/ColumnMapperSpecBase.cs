using System.Collections.Generic;
using ViewWeaver.Helpers.GridPopulation;

namespace ViewWeaver.Specs.Helpers.GridPopulation.ColumnMapperSpecs
{
	public class ColumnMapperSpecBase<T> : SpecBase
	{
		protected static IList<ColumnMapping<T>> mapping;
	}
}
