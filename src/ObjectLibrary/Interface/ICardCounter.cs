using ObjectLibrary.Items;

namespace ObjectLibrary.Interface
{
    public interface ICardCounter
    {
        public int Count { get; set; }
        public void AjustCount(Card card);
    }
}
