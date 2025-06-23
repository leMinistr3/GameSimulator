using ObjectLibrary.Items;
using System.Linq;

namespace GameSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();

            Shoe shoe = new Shoe(6, 1.5);

            for(int i = 0; i < shoe.cards.Count; i++)
            {
                var card = shoe.DrawCard();
                if(card != null)
                {
                    Console.WriteLine(card.ToString());
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            shoe.ReShuffle();
            shoe.cards.ForEach(card => { Console.WriteLine(card.ToString()); });

            Console.ReadLine();
        }
    }
}