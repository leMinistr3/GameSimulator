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
        private BjHand _dealerHand { get { return _hands.First(m => m._isDealer); } }
        private BjPlayer _player { get; set; }
        private List<BjHand> _hands { get; set; }
        private const int _maxTableHands = 8;
        private int _emptyTableHandCount { get { return _maxTableHands - _hands.Count; } }

        public BlackJackTable(Shoe shoe, double apBankRool, List<PlayerHandType> handsPosition)
        {
            if(handsPosition.Count + 1 > _maxTableHands)
            {
                throw new IndexOutOfRangeException("There's more player hands than table position");
            }

            _player = new BjPlayer(apBankRool);

            _shoe = shoe;

            _hands = new List<BjHand>();

            for (int i = 0; i < handsPosition.Count; i++)
            {
                switch (handsPosition[i])
                {
                    case PlayerHandType.Empty:
                        _hands.Add(new BjHand(i + 1, handsPosition[i]));
                        break;
                    case PlayerHandType.Player:
                        _hands.Add(new BjHand(i + 1, handsPosition[i]));
                        break;
                    case PlayerHandType.AdvantagePlayer:
                        _hands.Add(new BjHand(_player, i + 1));
                        break;
                        
                }
            }
            // Add Dealer hand as last position
            _hands.Add(new BjHand(_maxTableHands + 1));
        }

        public void RunSimulation()
        {

            while (!_shoe.isShoeEmpty && !_shoe.isLasthand)
            {
                // First Card
                foreach (BjHand hand in _hands)
                {
                    if (!AddNewCard(hand))
                    {
                        break;
                    }
                }
                //Secound Card
                foreach (BjHand hand in _hands)
                {
                    if (!AddNewCard(hand))
                    {
                        break;
                    }
                }

                foreach (BjHand hand in _hands)
                {
                    if (ResolveHand(hand) == false)
                    {
                        break;
                    }
                }
            }
            ResetTable();
        }

        private bool ResolveHand(BjHand hand)
        {
            HandResult? dealerHand = _dealerHand.Value();

            HandResult? playerHand = hand.Value();

            if (dealerHand != null && playerHand != null)
            {

            }

            return false;
        }

        private void ResetTable()
        {
            _hands.ForEach(m => m.Clear());

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
