using ObjectLibrary.Games.BlackJack.Interface;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjDealer : IBjHand
    {
        private List<Card> _cards { get; set; }

        public BjDealer()
        {
            _cards = new List<Card>();
        }

        public bool AddCard(Card? card)
        {
            if (card != null)
            {
                card.isHidden = _cards.Count == 1;
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
