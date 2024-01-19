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
    public class BjPlayer : IBjPlayer
    {
        public BjPlayer(int order, double bankroll)
        {
            this.order = order;
            this.bankroll = bankroll;
        }

        public void AddCard(Card card)
        {
            if (hands != null && hands.Any())
            {
                hands.First().AddCard(card);
            }
            else
            {
                hands = new List<BjHand>
                {
                    new BjHand(card)
                };
            }
        }

        public HandResult? HandTotal(int handId = 0)
        {
            if(hands != null && hands.Any())
            {
                return hands[handId].GetHandTotal();
            }
            return null;
        }

        public void ClearHand()
        {
            hands = null;
        }

        public int order { get; set; }
        private double bankroll { get; set; }
        public List<BjHand>? hands { get; set; }
    }
}
