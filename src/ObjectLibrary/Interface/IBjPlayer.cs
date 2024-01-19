using ObjectLibrary.Enum;
using ObjectLibrary.Games.BlackJack;
using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Interface
{
    public interface IBjPlayer
    {
        void AddCard(Card card);

        void ClearHand();

        int order { get; set; }
    }
}
