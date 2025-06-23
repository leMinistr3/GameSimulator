using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack.Model
{
    public class BjHandResult
    {
        public bool isSoft { get; set; }
        public bool isBlackJack { get; set; }
        public bool isSplit { get; set; }
        public int Value { get; set; }
        public int CardNumber { get; set; }
    }
}
