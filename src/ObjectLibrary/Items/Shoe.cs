using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Items
{
    public class Shoe
    {
        public Shoe(int numberOfDeck, double deckPenetration)
        {
            cards = new List<Card>();
            for (int i = 0; i < numberOfDeck; i++)
            {
                cards.AddRange(new Deck().cards);
            }
            cards.Shuffle();

            var numberOfCard = deckPenetration * 52;

            var discarded = cards.OrderByDescending(m => m.order).Take((int)numberOfCard).ToList();
            discarded.ForEach(m => m.isDiscard = true);
        }

        public Card? DrawCard()
        {
            var remainingCards = cards.Where(m => !m.isDiscard);
            if (remainingCards.Any())
            {
                var nextCard = remainingCards.OrderBy(m => m.order).First();
                nextCard.isDiscard = true;
                return nextCard;
            }

            return null;
        }

        public void ReShuffle(double deckPenetration)
        {
            cards.Shuffle();
            var numberOfCard = deckPenetration * 52;
            var discarded = cards.OrderByDescending(m => m.order).Take((int)numberOfCard).ToList();
            discarded.ForEach(m => m.isDiscard = true);
        }

        public List<Card> cards { get; set; }
    }
}
