using System.Net.Mime;

namespace ObjectLibrary.Games.BlackJack.Config
{
    public static class BjRule
    {
        public const bool DealerHitSoft17 = true;
        public const bool DoubleAfterSplit = true;
        public const bool DoubleMoreThan2Card = false;
        public const bool DoubleSoftTotal = true;
        public const bool BlackjackEvenMoney = false;
        public const double BalckjackPaid = 1.5; // 1.5 = 3:2
    }
}
