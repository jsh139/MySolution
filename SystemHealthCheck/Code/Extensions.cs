using System;
using System.Collections.Generic;

namespace SystemHealthCheck.Code
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items != null)
            {
                foreach (T item in items)
                {
                    action(item);
                }
            }
        }
    }
}
