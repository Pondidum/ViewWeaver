using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ViewWeaver.Extensions;

namespace ViewWeaver.Helpers.GridPopulation
{
	internal class ColumnMapper
	{
		public static IList<ColumnMapping<T>> Map<T>()
		{
			var allProperties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var readableProperties = allProperties.Where(p => p.CanRead & !p.GetIndexParameters().Any());

			var map = new List<ColumnMapping<T>>();

			foreach (var property in readableProperties)
			{
				var local = property;

				map.Add(new ColumnMapping<T>
						{
							Index = map.Count,
							Name = local.Name,
							Title = FormatName(local.Name),
							DataType = local.PropertyType,
							Populator = o => local.GetValue(o, null)
						});
			}

			return map;
		}

		private static String FormatName(String name)
		{
			return name;
		}

	}
}