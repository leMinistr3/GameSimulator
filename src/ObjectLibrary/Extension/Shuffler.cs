using ObjectLibrary.Items;
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

        public static void Shuffle(this List<Card> items)
        {        
            for (int i = 0; i < items.Count; i++)
            {
                int pos = r.Next(i, items.Count);
                Card temp = items[i];
                items[i] = items[pos];
                items[pos] = temp;

                items[i].order = i + 1;
                items[i].isDiscard = false;
            }
        }
    }
}
