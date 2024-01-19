using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjPlayer
    {
        public BjPlayer(int order)
        {
            this.order = order;
            hands = new List<BjHand>();
        }

        public int order { get; set; }

        public void NewHand(Card card1)
        {
            hands = new List<BjHand>
            {
                new BjHand(card1)
            };
        }

        public void ClearHand()
        {
            hands.Clear();
        }

        private List<BjHand> hands { get; set; }
    }
}
