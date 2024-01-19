using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjHand
    {
        private List<Card> cards { get; set; }

        public BjHand() 
        {
            cards = new List<Card>();
        }

        public BjHand(Card card1)
        {
            cards = new List<Card>();
            cards.Add(card1);
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void ClearHand()
        {
            cards.Clear();
        }

        public HandResult GetHandTotal()
        {
            HandResult result = new HandResult();
            int total = cards.Sum(m => m.number);
            result.Value = total;

            if (total < 11 && cards.Any(m => m.number == 1))
            {
                result.isSoft = true;
                result.Value = total + 10;
            }
            return result;
        }
    }

    public class HandResult
    {
        public bool isSoft { get; set; }
        public int Value { get; set; }
    }
}
