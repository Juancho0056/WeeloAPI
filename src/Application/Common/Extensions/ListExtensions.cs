using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Extensions
{
    public static class ListExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> consumer)
        {
            foreach (T item in enumerable)
            {
                consumer(item);
            }
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            if (list is List<T> listT)
            {
                listT.AddRange(items);
            }
            else
            {
                foreach (T item in items)
                {
                    list.Add(item);
                }
            }
        }
    }
}
