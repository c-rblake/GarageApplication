using System;
using System.Collections.Generic;

namespace Övning5
{
    public static class Extensions
    {
        public static System.Collections.Generic.IEnumerable<T> ReturnIfTrue<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            //validate
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (predicate is null) throw new ArgumentNullException(nameof(predicate));

            foreach (var item in source)
            {
                //yield return item; // Everything is returned
                if (predicate(item)) yield return item;
            }

        }
    }
}