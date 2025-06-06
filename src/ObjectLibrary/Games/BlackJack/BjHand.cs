using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Interface;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjHand
    {
        private List<Card> _cards { get; set; }
        private BjPlayer? _player { get; set; }
        public bool _isDealer { get; set; }

        public BjHand(bool isDealer = false)
        {
            _isDealer = isDealer;
            _cards = new List<Card>();
        }

        public BjHand(Card card, bool isDealer = false)
        {
            _isDealer = isDealer;
            if (_isDealer)
            {
                card.isHidden = true;
            }
            _cards = new List<Card>
            {
                card
            };
        }
        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void ClearHand()
        {
            _cards.Clear();
        }

        public HandResult GetHandTotal()
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
