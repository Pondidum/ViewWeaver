using System.Collections.Generic;

namespace ViewWeaver.Extensions
{
	internal static class IDictionaryExtensions
	{
		
		public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key)
		{
			Check.Self(self);

			TValue result;

			if (!self.TryGetValue(key, out result))
			{
				result = default(TValue);
			}

			return result;
		}
	}
}
