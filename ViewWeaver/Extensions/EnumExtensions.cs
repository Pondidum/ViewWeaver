using System.Linq;

namespace ViewWeaver.Extensions
{
    internal static class EnumExtensions
    {

        public static bool Has<T>(this T self, T value) where T : struct
        {
            Check.Enum(self);
            Check.Enum(value, "value");

            var intSelf = (int)(object)self;
            var intValue = (int)(object)value;

            return (intSelf | intValue) == intSelf;
        }

        public static bool HasAll<T>(this T self, params T[] values) where T : struct
        {
            Check.Enum(self);
            Check.Collection(values, "values");

            return values.All(v => self.Has(v));
        }

        public static bool HasAny<T>(this T self, params T[] values) where T : struct
        {
            Check.Enum(self);
            Check.Collection(values, "values");

            return values.Any(v => self.Has(v));
        }

        public static T Add<T>(this T self, params T[] values) where T : struct
        {
            Check.Enum(self);
            Check.Collection(values, "values");


            var result = (int)(object)self;
            var items = values.Cast<int>();

            result = items.Aggregate(result, (current, val) => current | val);

            return (T)(object)result;
        }

        public static T Remove<T>(this T self, params T[] values) where T : struct
        {
            Check.Enum(self);
            Check.Collection(values, "values");

            var result = (int)(object)self;
            var items = values.Where(v => self.Has(v)).Cast<int>();

            result =  items.Aggregate(result, (current, val) => current ^ val);
          
            return (T)(object)result;
        }
    }
}