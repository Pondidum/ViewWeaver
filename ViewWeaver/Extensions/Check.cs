using System;
using System.Collections;

namespace ViewWeaver.Extensions
{
    internal static class Check
    {
        public  static void Self(object self)
        {
            Check.Self(self, "self");
        }

        internal static void Self(object self, string name)
        {
            if (self == null) throw new ArgumentNullException(name);
        }

        internal static void Collection(ICollection collection)
        {
            Check.Collection(collection, "collection");
        }

        internal static void Collection(ICollection collection, string name)
        {
            if (collection == null) throw new ArgumentNullException(name);
        }

    }
}