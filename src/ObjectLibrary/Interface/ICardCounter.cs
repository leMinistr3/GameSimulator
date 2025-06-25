using ObjectLibrary.Items;

namespace ObjectLibrary.Interface
{
    public interface ICardCounter
    {
        public int TrueCount { get; }
        public void AjustCount(Card card, int deckNumber);
    }
}
