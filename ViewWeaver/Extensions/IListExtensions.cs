using System;
using System.Collections.Generic;

namespace ViewWeaver.Extensions
{
	internal static class IListExtensions
	{
		internal static void ForEach<T>(this IList<T> self, Action<T> action)
		{
			Check.Argument(self, "self");

			foreach (var item in self)
			{
				action(item);
			}
		}
	}
}