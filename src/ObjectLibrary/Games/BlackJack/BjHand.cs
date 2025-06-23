using ObjectLibrary.Enum;
using ObjectLibrary.Games.BlackJack.Interface;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjHand : IBjHand
    {
        private List<Card> _cards { get; set; }
        private BjPlayer? _player { get; set; }
        public bool isAdvantagePlayer { get { return _player != null; } }
        public bool isDisable { get; set; }

        public BjHand(int position, PlayerHandType type)
        {
            isDisable = type == PlayerHandType.Empty;
            _cards = new List<Card>();
        }

        public BjHand(BjPlayer player, int position)
        {
            _player = player;
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
