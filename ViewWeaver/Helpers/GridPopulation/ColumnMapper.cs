using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ViewWeaver.Extensions;

namespace ViewWeaver.Helpers.GridPopulation
{
    internal class ColumnMapper
    {
        public static IDictionary<int, Func<T, object>> Map<T>()
        {
            var allProperties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var readableProperties = allProperties.Where(p => p.CanRead & !p.GetIndexParameters().Any());
     
            var map = new Dictionary<int, Func<T, object>>();

            foreach (var property in readableProperties)
            {
                var local = property;
                map.Add(map.Count(), o => local.GetValue(o, null));
            }

            return map;
        }
    }
}