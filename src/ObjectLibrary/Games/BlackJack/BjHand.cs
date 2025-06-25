using ObjectLibrary.Enum;
using ObjectLibrary.Games.BlackJack.Interface;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjHand : IBjHand
    {
        private List<Card> _cards { get; set; }

        public BjHand()
        {
            _cards = new List<Card>();
        }

        public bool AddCard(Card? card)
        {
            if (card != null)
            {
                _cards.Add(card);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            _cards.Clear();
        }
    }
}
