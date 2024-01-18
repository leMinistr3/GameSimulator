using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class Shuffler
    {
        private static Random r = new Random();

        public static IList<T> Shuffle<T>(this IList<T> items)
        {
            for (int i = 0; i < items.Count - 1; i++)
            {
                int pos = r.Next(i, items.Count);
                T temp = items[i];
                items[i] = items[pos];
                items[pos] = temp;
            }
            return items;
        }
    }
}
