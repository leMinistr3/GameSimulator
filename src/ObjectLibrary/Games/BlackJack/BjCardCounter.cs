using ObjectLibrary.Interface;
using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjCardCounter : ICardCounter
    {
        public int Count { get; set; }
        public void AjustCount(Card card)
        {
            // Card 2, 3, 4, 5, 6 = Count - 1
            // Card 7, 8, 9 = Count + 0
            // Card 1, 10, 11, 12, 13 = Count + 1
            if(card.number != 1 && card.number < 7)
            {
                Count--;
            }
            if(card.number > 9 || card.number == 1)
            {
                Count++;
            }
        }
    }
}
