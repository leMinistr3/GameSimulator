using ObjectLibrary.Games.BlackJack.Model;
using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack.Interface
{
    public interface IBjHand
    {
        public bool AddCard(Card card);
        public void Clear();
        public BjHandResult Value();
    }
}
