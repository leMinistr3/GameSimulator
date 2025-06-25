using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack
{
    public class BjPosition
    {
        public int Position => _position;
        private BjPlayer? _bjPlayer { get; set; }
        private int _position {  get; set; }
        public List<BjHand> hands { get; set; }
        public bool isPlaying { get; set; }

        public BjPosition(int position) 
        { 
            _position = position;
            hands = new List<BjHand>() { new BjHand() };
        }

        public void DisablePosition()
        {
            isPlaying = false;
        }

        public void EnablePosition(BjPlayer? player)
        {
            _bjPlayer = player;
            isPlaying = true;
        }
    }
}
