using Revit.Services;
using System;

class Program
{
    static void Main(string[] args)
    {
        DeckService _deckService = new DeckService();
        bool @continue = true;
        do
        {
            Console.WriteLine("What to do?\n\n1 - add a deck\n2 - print a deck\n3 - quit\n4 - add a card\n5 - sort a deck\n6 - unsort a deck\n7 - get deck info");
            int command;
            try
            {
                command = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Input error.");
                continue;
            }
            switch (command)
            {
                case 1:
                    AddDeck(ref _deckService);
                    break;
                case 2:
                    PrintDeck(ref _deckService);
                    break;
                case 3:
                    @continue = false;
                    break;
                case 4:
                    AddCard(ref _deckService);
                    break;
                case 5:
                    SortDeck(ref _deckService);
                    break;
                case 6:
                    UnsortDeck(ref _deckService);
                    break;
                case 7:
                    GetDeckInfo(ref _deckService);
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        } while (@continue);
    }

    private static void GetDeckInfo(ref DeckService deckService)
    {
        Console.WriteLine("Enter the name of the deck: ");
        string name = Console.ReadLine();
        var deck = deckService.GetDeck(name);
        if (deck == null)
        {
            Console.WriteLine("The deck not found.\n");
            return;
        }
        Console.WriteLine($"Name: {deck.Name}\nCardsCount: {deck.Cards.Count}\nSorted: {deck.Sorted}\n");
    }

    private static void UnsortDeck(ref DeckService deckService)
    {
        Console.WriteLine("Enter the name of the deck: ");
        string name = Console.ReadLine();
        var deck = deckService.GetDeck(name);
        if (deck == null)
        {
            Console.WriteLine("The deck not found.\n");
            return;
        }
        deck.Unsort();
        Console.WriteLine($"The deck {deck.Name} has been successfully unsorted!\n");
    }

    private static void SortDeck(ref DeckService deckService)
    {
        Console.WriteLine("Enter the name of the deck: ");
        string name = Console.ReadLine();
        var deck = deckService.GetDeck(name);
        if (deck == null)
        {
            Console.WriteLine("The deck not found.\n");
            return;
        }
        if(deck.Sorted)
        {
            Console.WriteLine($"The deck {deck.Name} is already sorted.\n");
            return;
        }    
        deck.Sort();
        Console.WriteLine($"The deck {deck.Name} has been successfully sorted!\n");
    }

    private static void AddCard(ref DeckService deckService)
    {
        Console.WriteLine("Enter the name of the deck: ");
        string name = Console.ReadLine();
        var deck = deckService.GetDeck(name);
        if (deck == null)
        {
            Console.WriteLine("The deck not found.\n");
            return;
        }
        Console.WriteLine($"\n\nEnter a name for the new card: ");
        name = Console.ReadLine();
        ushort number;
        try
        {
            Console.WriteLine($"\nEnter the number of the card: ");
            number = ushort.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Input error.\n");
            return;
        }
        var result = deckService.AddCard(ref deck, name, number);
        Console.WriteLine(result.Message);
    }

    private static void PrintDeck(ref DeckService deckService)
    {
        Console.WriteLine("Enter the name of the deck: ");
        string name = Console.ReadLine();
        var deck = deckService.GetDeck(name);
        if (deck == null)
        {
            Console.WriteLine("The deck not found.\n");
            return;
        }
        Console.WriteLine($"\n\nThe {name} deck contains folowing cards:\n");
        foreach (var item in deck.Cards)
        {
            Console.WriteLine($"{item.Name} {item.Number}\n");
        }
    }

    private static void AddDeck(ref DeckService deckService)
    {
        Console.WriteLine("Enter a name for the new deck: ");
        string name = Console.ReadLine();
        Console.WriteLine($"How many card will {name} contain? ");
        ushort capacity;
        try
        {
            capacity = ushort.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Input error.");
            return;
        }
        var result = deckService.AddDeck(name, capacity);
        Console.WriteLine(result.Message);
    }
}