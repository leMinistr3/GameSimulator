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
        public BlackJackTable(int playerCount, int numberOfDeck, double deckPenetration, double playerBankroll)
        {
            this.shoe = new Shoe(numberOfDeck, deckPenetration);
            this.deckPenetration = deckPenetration;

            players = new List<BjPlayer>();

            for (int i = 0; i < playerCount; i++)
            {
                BjPlayer player = new BjPlayer(i + 1, playerBankroll);
                players.Add(player);
            }

            dealer = new BjDealer(playerCount);
        }

        public void RunSimulation()
        {
            List<IBjPlayer> tablePlayers = new List<IBjPlayer>();
            tablePlayers.AddRange(players);
            tablePlayers.Add(dealer);
            tablePlayers = tablePlayers.OrderBy(m => m.order).ToList();

            while (!shoe.isShoeEmpty)
            {
                // First Card
                foreach (IBjPlayer player in tablePlayers)
                {
                    if (AddNewCard(player) == false)
                    {
                        break;
                    }
                }
                //Secound Card
                foreach (IBjPlayer player in tablePlayers)
                {
                    if (AddNewCard(player) == false)
                    {
                        break;
                    }
                }

                foreach(BjPlayer bjPlayer in players)
                {
                    if (ResolveHand(bjPlayer) == false)
                    {
                        break;
                    }
                }
            }
        }

        private bool ResolveHand(BjPlayer bjPlayer)
        {
            HandResult? dealerHand = dealer.HandTotal();

            HandResult? playerHand = bjPlayer.HandTotal();

            if(dealerHand != null && playerHand != null)
            {

            }

            return false;
        }

        private void ResetTable()
        {
            players.ForEach(m => m.ClearHand());
            dealer.ClearHand();

            shoe.ReShuffle(deckPenetration);
        }

        private bool AddNewCard(IBjPlayer player)
        {
            var card = shoe.DrawCard();
            if (card != null)
            {
                player.AddCard(card);
                return true;
            }
            else
            {
                ResetTable();
                return false;
            }
        }

        private double deckPenetration { get; set; }
        private Shoe shoe { get; set; }
        private BjDealer dealer { get; set; }
        private List<BjPlayer> players { get; set; }

    }
}
