using ObjectLibrary.Games.BlackJack.Interface;
using ObjectLibrary.Games.BlackJack.Model;
using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
