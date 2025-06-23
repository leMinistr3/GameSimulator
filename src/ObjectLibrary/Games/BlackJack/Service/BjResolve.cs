using ObjectLibrary.Enum;
using ObjectLibrary.Games.BlackJack.Config;
using ObjectLibrary.Games.BlackJack.Helper;
using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack.Service
{
    public static class BjResolve
    {
        private static bool CanDouble(List<Card> hands) => hands.Count == 2 || BjRule.DoubleMoreThan2Card;

        public static BjAction PlayerAction(List<Card> playerHand, List<Card> dealerHand)
        {
            int total = playerHand.BlackJackTotal();
            int dealerTotal = dealerHand.BlackJackTotal();
            BjSplit bjSplit = BjSplit.No;
            if (total >= 20)
            {
                return BjAction.Stand;
            }
            if (playerHand.IsSoftTotal())
            {
                BjSoftTotal softTotal = (BjSoftTotal)softMatrix[total - 12, dealerTotal - 1];
                return ConvertToBjAction(softTotal, playerHand);
            }
            if (playerHand.CanSplit())
            {
                bjSplit = (BjSplit)splitMatrix[playerHand.SplitNumber() - 1, dealerTotal - 1];
                if(bjSplit == BjSplit.Split || (bjSplit == BjSplit.SplitIfDouble && BjRule.DoubleAfterSplit))
                {
                    return BjAction.Split;
                }
            }
            BjHardTotal hardTotal = (BjHardTotal)hardMatrix[total, dealerTotal - 1];
            return ConvertToBjAction(hardTotal, playerHand);
        }

        private static BjAction ConvertToBjAction(BjSoftTotal total, List<Card> handCards)
        {
            return total switch
            {
                BjSoftTotal.Hit => BjAction.Hit,
                BjSoftTotal.Stand => BjAction.Stand,
                BjSoftTotal.DoubleOrStand => CanDouble(handCards) ? BjAction.Double : BjAction.Stand,
                BjSoftTotal.DoubleOrHit => CanDouble(handCards) ? BjAction.Double : BjAction.Hit,
                _ => throw new ArgumentOutOfRangeException(nameof(total))
            };
        }

        private static BjAction ConvertToBjAction(BjHardTotal total, List<Card> handCards)
        {
            return total switch
            {
                BjHardTotal.Hit => BjAction.Hit,
                BjHardTotal.Stand => BjAction.Stand,
                BjHardTotal.DoubleOrHit => CanDouble(handCards) ? BjAction.Double : BjAction.Hit,
                _ => throw new ArgumentOutOfRangeException(nameof(total))
            };
        }

        // Matrix Website : https://www.blackjackapprenticeship.com/wp-con.tent/uploads/2018/08/BJA_Basic_Strategy.jpg
        private static char[,] splitMatrix =
        { 
          // ***************    DEALER CARD    *****************
          //  Ace  2    3    4    5    6    7    8    9    10  
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// A,A
            { 'N', 'D', 'D', 'S', 'S', 'S', 'S', 'N', 'N', 'N'},// 2,2
            { 'N', 'D', 'D', 'S', 'S', 'S', 'S', 'N', 'N', 'N'},// 3,3
            { 'N', 'N', 'N', 'N', 'D', 'D', 'N', 'N', 'N', 'N'},// 4,4
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},// 5,5
            { 'N', 'D', 'S', 'S', 'S', 'S', 'N', 'N', 'N', 'N'},// 6,6
            { 'N', 'S', 'S', 'S', 'S', 'S', 'S', 'N', 'N', 'N'},// 7,7
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// 8,8
            { 'N', 'S', 'S', 'S', 'S', 'S', 'N', 'S', 'S', 'N'},// 9,9
            { 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N'},// 10,10
        };

        private static char[,] softMatrix =
        { 
          // ***************    DEALER CARD    *****************
          //  Ace  2    3    4    5    6    7    8    9    10  
            { 'H', 'H', 'H', 'H', 'D', 'D', 'H', 'H', 'H', 'H'},// A2
            { 'H', 'H', 'H', 'H', 'D', 'D', 'H', 'H', 'H', 'H'},// A3
            { 'H', 'H', 'H', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// A4
            { 'H', 'H', 'H', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// A5
            { 'H', 'H', 'D', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// A6
            { 'H', 'T', 'T', 'T', 'T', 'T', 'S', 'S', 'H', 'H'},// A7
            { 'S', 'S', 'S', 'S', 'S', 'T', 'S', 'S', 'S', 'S'},// A8
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// A9
        };

        private static char[,] hardMatrix =
        { 
          // ***************    DEALER CARD    *****************
          //  Ace  2    3    4    5    6    7    8    9    10  
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 0
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 1
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 2
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 3
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 4
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 5
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 6
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 7
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 7
            { 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H', 'H'},// 8
            { 'H', 'H', 'D', 'D', 'D', 'D', 'H', 'H', 'H', 'H'},// 9
            { 'H', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'H'},// 10
            { 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D', 'D'},// 11
            { 'H', 'H', 'H', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 12
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 13
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 14
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 15
            { 'H', 'S', 'S', 'S', 'S', 'S', 'H', 'H', 'H', 'H'},// 16
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// 17
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// 18
            { 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S', 'S'},// 19
        };
    }
}
