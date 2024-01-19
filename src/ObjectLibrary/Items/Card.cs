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

        public override string ToString()
        {
            string result = (number > 9) ? number.ToString() : number.ToString() + " ";

            switch (face)
            {
                case CardFace.None:
                    result += "      ";
                    break;
                case CardFace.Jack:
                    result += " " + face + " ";
                    break;
                case CardFace.Queen:
                    result += " " + face;
                    break;
                case CardFace.King:
                    result += " " + face + " ";
                    break;
            }

            switch (suit)
            {
                case Suit.Heart:
                    result += " " + suit + "  ";
                    break;
                case Suit.Club:
                    result += " " + suit + "   ";
                    break;
                case Suit.Diamond:
                    result += " " + suit;
                    break;
                case Suit.Spade:
                    result += " " + suit + "  ";
                    break;
            }

            result += " " + order;

            result += " " + ((isDiscard) ? "*" : "");

            return result;
        }

        private CardFace GetCardFace()
        {
            if (this.number == 11)
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