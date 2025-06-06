using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Items
{
    public class Shoe
    {
        public bool isShoeEmpty { get; set; }
        public bool isLasthand { get; set; }
        public int shoeDividerPosition { get; private set; }
        public List<Card> cards { get; set; }
        private double _deckPenetration { get; set; }

        public Shoe(int numberOfDeck, double deckPenetration)
        {
            _deckPenetration = deckPenetration;
            cards = new List<Card>();
            for (int i = 0; i < numberOfDeck; i++)
            {
                cards.AddRange(new Deck().cards);
            }
            cards.Shuffle();

            shoeDividerPosition = (int)(cards.Count * _deckPenetration);
        }

        public Card? DrawCard()
        {
            var remainingCards = cards.Where(m => !m.isDiscard);
            if (remainingCards.Any())
            {
                var nextCard = remainingCards.OrderBy(m => m.order).First();
                isLasthand = (nextCard.order >= shoeDividerPosition);
                nextCard.isDiscard = true;
                return nextCard;
            }
            isShoeEmpty = true;
            return null;
        }

        public void ReShuffle()
        {
            cards.Shuffle();
            shoeDividerPosition = (int)(cards.Count * _deckPenetration);
            isShoeEmpty = false;
            isLasthand = false;
        }
    }
}
