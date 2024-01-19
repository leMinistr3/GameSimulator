using ObjectLibrary.Enum;
using ObjectLibrary.Interface;
using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjDealer : IBjPlayer
    {
        public BjDealer(int order)
        {
            this.order = order;
        }

        public void AddCard(Card card)
        {
            if(hand == null)
            {
                hand = new BjHand(card, true);
            }
            else
            {
                hand.AddCard(card);
            }
        }
        public void ClearHand()
        {
            hand = null;
        }

        public HandResult? HandTotal()
        {
            if(hand != null)
            {
                return hand.GetHandTotal();
            }
            return null;
        }

        public int order { get; set; }
        private BjHand? hand { get; set; }
    }
}
