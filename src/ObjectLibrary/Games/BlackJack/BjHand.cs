using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Enum;
using ObjectLibrary.Interface;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjHand
    {
        private List<Card> _cards { get; set; }
        private BjPlayer? _player { get; set; }
        public bool _isDealer { get; set; }
        public bool _isAdvantagePlayer { get { return _player !=  null; } } 
        public bool _isPositionEmpty { get; set; }

        public BjHand(int position, PlayerHandType type)
        {
            _isDealer = false;
            _isPositionEmpty = type == PlayerHandType.Empty;
            _cards = new List<Card>();
        }

        public BjHand(int position)
        {
            _isDealer = true;
            _cards = new List<Card>();
        }

        public BjHand(BjPlayer player, int position)
        {
            _player = player;
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public HandResult Value()
        {
            HandResult result = new HandResult();
            int total = _cards.Where(m => !m.isHidden).Sum(m => m.number);
            result.Value = total;

            if (_cards.Any(m => m.number == 1) && (result.Value + 10) <= 21)
            {
                result.isSoft = true;
                result.Value += 10;
            }

            return result;
        }
    }

    public class HandResult
    {
        public bool isSoft { get; set; }
        public int Value { get; set; }
    }
}
