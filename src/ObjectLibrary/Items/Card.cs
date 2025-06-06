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
        }

        public int number { get; private set; }
        public bool isRed { get {return suit == Suit.Heart || suit == Suit.Diamond; } }
        public bool isHidden { get; set; }
        public Suit suit { get; private set; }
        public CardFace face { get { return GetCardFace(); } }
        public int order { get; set; }
        public bool isDiscard { get; set; }

        public override string ToString()
        {
            string num = (face != CardFace.None) ? face.ToString() : number.ToString();

            return $"{num} of {suit}";
        }

        private CardFace GetCardFace()
        {
            if (number == 11)
            {
                return CardFace.Jack;
            }
            if (number == 12)
            {
                return CardFace.Queen;
            }
            if (number == 13)
            {
                return CardFace.King;
            }
            return CardFace.None;
        }
    }
}