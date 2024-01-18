using ObjectLibrary.Enum;

namespace ObjectLibrary.Items
{
    public class Card
    {
        public Card(int _number, int _order, Suit _suit)
        {
            number = _number;
            order = _order;
            suit = _suit;
            isRed = _suit == Suit.Heart || _suit == Suit.Diamond;
            face = GetCardFace();
        }

        public int number { get; private set; }
        public bool isRed { get; private set; }
        public Suit suit { get; private set; }
        public CardFace face { get; private set; }
        public int order { get; set; }
        public bool isDiscard { get; set; }

        private CardFace GetCardFace()
        {
            if(this.number == 11)
            {
                return CardFace.Jack;
            }
            if (this.number == 12)
            {
                return CardFace.Queen;
            }
            if (this.number == 13)
            {
                return CardFace.King;
            }
            return CardFace.None;
        }
    }
}