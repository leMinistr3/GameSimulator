using ObjectLibrary.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLibrary.Games.BlackJack.Helper
{
    public static class BjHelper
    {
        public static int BlackJackTotal(this List<Card> cards)
        {
            if (cards == null)
                return 0;

            var shownCards = cards.Where(c => c?.isHidden == false);
            int total = shownCards.Sum(c => c.number > 10 ? 10 : c.number);

            if (cards.IsSoftTotal())
                total += 10;

            return total;
        }

        public static bool IsSoftTotal(this List<Card> cards)
        {
            if (cards == null)
                return false;

            var shownCards = cards.Where(c => c?.isHidden == false);
            int total = shownCards.Sum(c => c.number > 10 ? 10 : c.number);

            return (shownCards.Any(c => c.number == 1) && total + 10 <= 21);
        }

        public static bool CanSplit(this List<Card> cards)
        {
            if (cards == null)
                return false;

            var shownCards = cards.Where(c => c?.isHidden == false);

            return (shownCards.Count() == 2 && shownCards.First().number == shownCards.Last().number);
        }

        public static int SplitNumber(this List<Card> cards)
        {
            if (cards == null)
                return 0;

            if (!cards.CanSplit())
                return 0;

            var shownCards = cards.Where(c => c?.isHidden == false);
            int total = shownCards.Sum(c => c.number > 10 ? 10 : c.number);

            return total / 2;

        }
    }
}
