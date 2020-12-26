using System;
using System.Collections.Generic;
using System.Linq;

namespace Revit.Models
{
    public class Deck
    {
        static readonly ushort _limit = 100;
        private readonly ushort limit;
        public string Name { get; set; }
        public bool Sorted { get; set; } = false;
        public List<Card> Cards;
        public Deck(string name, ushort capacity)
        {
            if (capacity > _limit)
                throw new Exception("Limit overflow!");
           
            Name = name;
            limit = capacity;
            Cards = new List<Card>(capacity);
        }

        public OperationResult AddCard(ushort number, string name)
        {
            if (Cards.Count == limit)
                return new OperationResult("Limit overflow!", false);

            if(Cards.Exists(x => x.Name == name))
                return new OperationResult($"The {Name} deck already has a card named {name}.", false);

            if (Cards.Exists(x => x.Number == number))
                return new OperationResult($"The {Name} deck already has a card with the {number} number.", false);

            Cards.Add(new Card(number, name));
            Sorted = false;
            return new OperationResult($"The card {name} has been successfully added to the {Name} deck", true);
        }

        internal void Unsort()
        {
            Random random = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
            Sorted = false;
        }

        internal void Sort()
        {
            Cards = Cards.OrderBy(x => x.Number).ToList();
            Sorted = true;
        }
    }
}
