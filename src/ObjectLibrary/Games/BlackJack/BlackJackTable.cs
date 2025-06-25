using ObjectLibrary.Enum;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BlackJackTable
    {
        private const int _maxTableHands = 8;
        private double deckPenetration { get; set; }
        private Shoe _shoe { get; set; }
        private BjDealer _dealer { get; set; }
        private BjPlayer _player { get; set; }
        private List<BjPosition> _positionList => new List<BjPosition>
        {
            TablePosition1,
            TablePosition2,
            TablePosition3,
            TablePosition4,
            TablePosition5,
            TablePosition6,
            TablePosition7,
            TablePosition8
        }.Where(p => p.isPlaying).ToList();

        public BjPosition TablePosition1 { get; set; }
        public BjPosition TablePosition2 { get; set; }
        public BjPosition TablePosition3 { get; set; }
        public BjPosition TablePosition4 { get; set; }
        public BjPosition TablePosition5 { get; set; }
        public BjPosition TablePosition6 { get; set; }
        public BjPosition TablePosition7 { get; set; }
        public BjPosition TablePosition8 { get; set; }

        public BlackJackTable(Shoe shoe, BjPlayer player, List<PlayerHandType> handsPosition)
        {
            if (handsPosition.Count > _maxTableHands)
                throw new IndexOutOfRangeException("Too many player hands for table positions.");

            if (handsPosition.Count(m => m == PlayerHandType.AdvantagePlayer) < 1)
                throw new Exception("We need one Advantage player on the table");

            _player = player;
            _shoe = shoe;
            _dealer = new BjDealer();

            TablePosition1 = new BjPosition(1);
            TablePosition2 = new BjPosition(2);
            TablePosition3 = new BjPosition(3);
            TablePosition4 = new BjPosition(4);
            TablePosition5 = new BjPosition(5);
            TablePosition6 = new BjPosition(6);
            TablePosition7 = new BjPosition(7);
            TablePosition8 = new BjPosition(8);

            for (int i = 1; i < handsPosition.Count; i++)
            {
                if (handsPosition[i] != PlayerHandType.Empty)
                {
                    SetTablePosition(i, handsPosition[i] == PlayerHandType.AdvantagePlayer ? player : null);
                }
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
                    //if (!ResolveHand(hand))
                    //  break;
                }
            }
            ResetTable();
        }

        private void ResetTable()
        {
            _positionList.ForEach(position => position.hands.ForEach(hand => hand.Clear()));
            _dealer.Clear();
            _shoe.ReShuffle();
        }

        private bool DealInitialCards()
        {
            foreach (BjPosition position in _positionList)
            {
                if (position.hands.Any(hand => !hand.AddCard(_shoe.DrawCard())))
                    return false;
            }
            return _dealer.AddCard(_shoe.DrawCard());
        }

        private void SetTablePosition(int position, BjPlayer? player)
        {
            switch (position)
            {
                case 1:
                    TablePosition1.EnablePosition(player); break;
                case 2:
                    TablePosition2.EnablePosition(player); break;
                case 3:
                    TablePosition3.EnablePosition(player); break;
                case 4:
                    TablePosition4.EnablePosition(player); break;
                case 5:
                    TablePosition5.EnablePosition(player); break;
                case 6:
                    TablePosition6.EnablePosition(player); break;
                case 7:
                    TablePosition7.EnablePosition(player); break;
                case 8:
                    TablePosition8.EnablePosition(player); break;

            }
        }
    }
}
