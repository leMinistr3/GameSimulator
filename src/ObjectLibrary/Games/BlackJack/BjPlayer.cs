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
    public class BjPlayer
    {
        private double _bankroll { get; set; }

        public BjPlayer(double bankroll)
        {
            _bankroll = bankroll;
        }
    }
}
