using ObjectLibrary.Enum;
using ObjectLibrary.Games.BlackJack.Model;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BlackJackTable
    {
        private double deckPenetration { get; set; }
        private Shoe _shoe { get; set; }
        private BjDealer _dealer { get; set; }
        private BjPlayer _player { get; set; }
        private List<BjHand> _hands { get; set; }
        private const int _maxTableHands = 8;

        public BlackJackTable(Shoe shoe, double apBankRoll, List<PlayerHandType> handsPosition)
        {
            if (handsPosition.Count + 1 > _maxTableHands)
                throw new IndexOutOfRangeException("Too many player hands for table positions.");

            _player = new BjPlayer(apBankRoll);
            _shoe = shoe;
            _hands = new List<BjHand>();
            _dealer = new BjDealer();

            for (int i = 0; i < handsPosition.Count; i++)
            {
                var handType = handsPosition[i];
                _hands.Add(handType == PlayerHandType.AdvantagePlayer ? new BjHand(_player, i + 1) : new BjHand(i + 1, handType));
            }
        }

        public void RunSimulation()
        {
            while (!_shoe.isShoeEmpty && !_shoe.isLasthand)
            {
                // Deal initial two cards to players and dealer
                if (!DealInitialCards() || !DealInitialCards())
                    break;

                // Resolve each player's hand
                foreach (BjHand hand in _hands)
                {
                    if (!ResolveHand(hand))
                        break;
                }
            }
            ResetTable();
        }

        private bool ResolveHand(BjHand hand)
        {
            HandResult dealerHand = _dealer.Value();

            HandResult playerHand = hand.Value();

            return false;
        }

        private void ResetTable()
        {
            _hands.ForEach(m => m.Clear());
            _dealer.Clear();
            _shoe.ReShuffle();
        }

        private bool DealInitialCards()
        {
            foreach (BjHand hand in _hands)
            {
                if (!hand.isDisable || !hand.AddCard(_shoe.DrawCard()))
                    return false;
            }
            return _dealer.AddCard(_shoe.DrawCard());
        }
    }
}
