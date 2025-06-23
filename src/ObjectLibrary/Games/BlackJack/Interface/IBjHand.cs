using ObjectLibrary.Items;

namespace ObjectLibrary.Games.BlackJack.Interface
{
    public interface IBjHand
    {
        public bool AddCard(Card card);
        public void Clear();
    }
}
