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
        public BlackJackTable(int playerNumber, int numberOfDeck, double deckPenetration)
        {
            this.shoe = new Shoe(numberOfDeck, deckPenetration);
            this.deckPenetration = deckPenetration;

            players = new List<BjPlayer>();

            for(int i = 0; i < playerNumber; i++)
            {
                BjPlayer player = new BjPlayer(i + 1);
                players.Add(player);
            }
        }

        public void RunSimulation()
        {
            foreach(BjPlayer player in players)
            {
                var card = shoe.DrawCard();
                if(card != null)
                {
                    player.NewHand(card);
                }
                else
                {
                    ResetTable();
                }
            }
        }

        public void ResetTable()
        {
            players.ForEach(m => m.ClearHand());
            dealerHand.ClearHand();

            shoe.ReShuffle(deckPenetration);
        }

        private double deckPenetration { get; set; }
        private Shoe shoe { get; set; }
        private BjHand dealerHand { get; set; } 
        public List<BjPlayer> players { get; set; }

    }
}
