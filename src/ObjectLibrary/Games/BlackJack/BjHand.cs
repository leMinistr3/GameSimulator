using ObjectLibrary.Enum;
using ObjectLibrary.Games.BlackJack.Interface;
using ObjectLibrary.Games.BlackJack.Model;
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

        // Remove HandResult and move this logic to BjResolve
        public BjHandResult Value()
        {
            BjHandResult result = new BjHandResult();
            int total = _cards.Where(m => !m.isHidden).Sum(m => (m.number > 10) ? 10 : m.number);
            result.Value = total;
            result.CardNumber = _cards.Count();

            if (_cards.Any(m => m.number == 1) && (result.Value + 10) <= 21)
            {
                result.isSoft = true;
                result.Value += 10;
                result.isBlackJack = (_cards.Count == 2 && result.Value == 21);
            }
            if(_cards.Count() == 2)
            {
                result.isSplit = _cards[0].number == _cards[1].number;
            }

            return result;
        }
    }
}
