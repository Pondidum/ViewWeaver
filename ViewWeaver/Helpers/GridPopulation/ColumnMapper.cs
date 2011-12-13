using System;
using System.Linq;
using System.Reflection;

namespace ViewWeaver.Helpers.GridPopulation
{
	public class ColumnMapper
	{
		public static ColumnMappingCollection<T> AutomapForType<T>()
		{
			var allProperties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
			var readableProperties = allProperties.Where(p => p.CanRead &&
															  p.GetGetMethod() != null &&
															  p.GetGetMethod().IsPublic &&
															  !p.GetIndexParameters().Any());

			var map = new ColumnMappingCollection<T>();

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

		public static ColumnMappingCollection<T> ForType<T>(params Action<FluentColumnMapping<T>>[] columns)
		{
			var collection = new ColumnMappingCollection<T>();

			foreach (var fluentConfig in columns)
			{
				var config = new ColumnMapping<T>();
				fluentConfig.Invoke(new FluentColumnMapping<T>(config));

				collection.Add(config);
			}

			return collection;
		}
	}
}