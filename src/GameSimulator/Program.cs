using ObjectLibrary.Items;

namespace GameSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Deck deck = new Deck();


            

            Console.WriteLine("FIRST");
            deck.cards.ForEach(card => { Console.WriteLine($"{card.number} {card.suit}"); });
            deck.cards.Shuffle();

            Console.WriteLine("New Shuffle");

            deck.cards.ForEach(card => { Console.WriteLine($"{card.number} {card.suit}"); });
            deck.cards.Shuffle();


            Console.WriteLine("New Shuffle");

            deck.cards.ForEach(card => { Console.WriteLine($"{card.number} {card.suit}"); });
            deck.cards.Shuffle();


            Console.WriteLine("New Shuffle");

            deck.cards.ForEach(card => { Console.WriteLine($"{card.number} {card.suit}"); });

            Console.ReadLine();
        }
    }
}