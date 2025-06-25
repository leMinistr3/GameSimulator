using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        public double BankRoll => _bankroll;

        private double _bankroll { get; set; }
        private bool _isBaseBet => _baseBet != null;
        private int? _baseBet {  get; set; }
        private List<int>? _betSpread { get; set; }
        private BjCardCounter? _cardcounter { get; set; }

        private int _currentBet { get; set; }

        public BjPlayer(double bankroll, int baseBet)
        {
            _bankroll = bankroll;
            _baseBet = baseBet;
        }

        public BjPlayer(double bankroll, List<int> betSpread, BjCardCounter _cardCounter)
        {
            _bankroll = bankroll;
            _betSpread = betSpread;
            _cardcounter = _cardCounter;
        }

        public bool PlaceBet()
        {
            int betValue = _isBaseBet
                ? _baseBet.Value
                : GetBetFromSpread();

            if (BankRoll >= betValue)
            {
                _bankroll -= betValue;
                _currentBet += betValue;
                return true;
            }
            return false;
        }

        private int GetBetFromSpread()
        {
            if (_cardcounter == null)
                throw new Exception("Card counter required for bet spread");
            if (_betSpread == null)
                throw new Exception("Bet spread required with card counter");

            int trueCount = _cardcounter.TrueCount;
            if (trueCount < 1)
                return _betSpread[0];
            if (trueCount >= _betSpread.Count)
                return _betSpread.Last();
            return _betSpread[trueCount];
        }
    }
}
