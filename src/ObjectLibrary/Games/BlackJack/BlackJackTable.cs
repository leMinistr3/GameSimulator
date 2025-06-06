using ObjectLibrary.Enum;
using ObjectLibrary.Interface;
using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack
{
    public class BlackJackTable
    {
        private double deckPenetration { get; set; }
        private Shoe _shoe { get; set; }
        private BjHand _dealerHand { get { return _hands.Find(m => m.)} }
        private BjPlayer _player { get; set; }
        private List<BjHand> _hands { get; set; }
        private const int _maxTableHands = 8;
        private int _emptyTableHandCount { get { return _maxTableHands - _hands.Count; } }

        public BlackJackTable(Shoe shoe, int playerCount, int advantagePlayerPosition, double advantagePlayerBankRool, int advantagePlayerHandCount = 1)
        {
            playerCount = (playerCount > _maxTableHands) ? _maxTableHands : playerCount;
            advantagePlayerHandCount = _emptyTableHandCount < (advantagePlayerHandCount - 1) ? _emptyTableHandCount : advantagePlayerHandCount;

            _shoe = shoe;

            _players = new List<BjPlayer>();

            for (int i = 0; i < playerCount; i++)
            {
                BjPlayer player = (i == (advantagePlayerPosition - 1)) ? new BjPlayer(i + 1, advantagePlayerBankRool) : new BjPlayer(i + 1);
                _players.Add(player);
            }

            _dealer = new BjDealer(playerCount);
        }

        public void RunSimulation()
        {
            List<IBjPlayer> tablePlayers = new List<IBjPlayer>();
            tablePlayers.AddRange(_players);
            tablePlayers.Add(_dealer);
            tablePlayers = tablePlayers.OrderBy(m => m.order).ToList();

            while (!_shoe.isShoeEmpty && !_shoe.isLasthand)
            {
                // First Card
                foreach (IBjPlayer player in tablePlayers)
                {
                    if (!AddNewCard(player))
                    {
                        break;
                    }
                }
                //Secound Card
                foreach (IBjPlayer player in tablePlayers)
                {
                    if (!AddNewCard(player))
                    {
                        break;
                    }
                }

                foreach (IBjPlayer bjPlayer in tablePlayers)
                {
                    if (ResolveHand(bjPlayer) == false)
                    {
                        break;
                    }
                }
            }
            ResetTable();
        }

        private bool ResolveHand(IBjPlayer bjPlayer)
        {
            HandResult? dealerHand = _dealer.HandTotal();

            HandResult? playerHand = bjPlayer.HandTotal();

            if (dealerHand != null && playerHand != null)
            {

            }

            return false;
        }

        private void ResetTable()
        {
            _hands.ForEach(m => m.ClearHand());

            _shoe.ReShuffle();
        }

        private bool AddNewCard(BjHand hand)
        {
            var card = _shoe.DrawCard();
            if (card != null)
            {
                hand.AddCard(card);
                return true;
            }
            return false;
        }
    }
}
