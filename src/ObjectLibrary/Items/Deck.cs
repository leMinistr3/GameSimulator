using ObjectLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Items
{
    public class Deck
    {
        private static Random r = new Random();
        public Deck()
        {
            cards = new List<Card>();
            for (int i = 1; i <= 52; i++)
            {
                int number = i % 13;
                number = (number == 0) ? 13 : number;
                Suit suit = (Suit)(i / 13);
                suit = (i == 13) ? Suit.Heart : suit;
                suit = (i == 26) ? Suit.Club : suit;
                suit = (i == 39) ? Suit.Diamond : suit;
                suit = (i == 52) ? Suit.Spade : suit;

                cards.Add(new Card(number, i, suit));
            }
        }
        public List<Card> cards { get; set; }

        public void Shuffle()
        {
            cards.Shuffle();
        }
    }
}
