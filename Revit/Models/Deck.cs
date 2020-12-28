using System;
using System.Collections.Generic;
using System.Linq;

namespace Revit.Models
{
    public class Deck
    {
        private const ushort Limit = 100;
        private readonly ushort _limit;
        public string Name { get; set; }
        public bool Sorted { get; private set; }

        public List<Card> Cards;

        public Deck(string name, ushort capacity)
        {
            if (capacity > Limit)
                throw new Exception("Limit overflow!");

            Name = name;
            _limit = capacity;
            Cards = new List<Card>(capacity);
        }

        public OperationResult AddCard(ushort number, string name)
        {
            if (Cards.Count == _limit)
                return new OperationResult("Limit overflow!", false);

            if (Cards.Exists(x => x.Name == name))
                return new OperationResult($"The {Name} deck already has a card named {name}.", false);

            if (Cards.Exists(x => x.Number == number))
                return new OperationResult($"The {Name} deck already has a card with the {number} number.", false);

            Cards.Add(new Card(number, name));
            Sorted = false;
            return new OperationResult($"The card {name} has been successfully added to the {Name} deck", true);
        }

        public void Unsort()
        {
            var random = new Random();

            var n = Cards.Count;

            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                var value = Cards[k];
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