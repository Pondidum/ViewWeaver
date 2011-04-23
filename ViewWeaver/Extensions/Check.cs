using System;
using System.Collections;

namespace ViewWeaver.Extensions
{
    internal static class Check
    {
        public static void Self(object self)
        {
            Check.Self(self, "self");
        }

        internal static void Self(object self, string name)
        {
            if (self == null)
            {
                 throw new ArgumentNullException(name);
            }
        }

        internal static void Collection(ICollection collection)
        {
            Check.Collection(collection, "collection");
        }

        internal static void Collection(ICollection collection, string name)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void Enum<T>(T self) where T : struct
        {
            Check.Enum(self, "enum");
        }

        internal static void Enum<T>(T self, string name) where T : struct
        {
            if (!self.GetType().IsEnum)
            {
                throw new ArgumentException(string.Format("{0} is not an Enum.", name), name);
            }
        }

        internal static void Configuration(object config, string format, params object[] args)
        {
            if (config == null)
            {
                throw new InvalidConfigurationException(string.Format(format, args));
            }
        }

    }

}
