using Revit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit.Services
{
    public class DeckService
    {
        private readonly List<Deck> _decks = new List<Deck>();

        public Deck GetDeck(string name)
        {
            var deck = _decks.FirstOrDefault(x => x.Name == name);

            return deck;
        }

        public OperationResult AddDeck(string name, ushort capacity)
        {
            if (_decks.Exists(x => x.Name == name))
                return new OperationResult($"The name {name} is taken.", false);
            try
            {
                var deck = new Deck(name, capacity);
                _decks.Add(deck);
                return new OperationResult(
                    $"The {name} deck has been successfully added!", true);
            }
            catch (Exception e)
            {
                return new OperationResult(e.Message, false);
            }
        }

        public static OperationResult AddCard(ref Deck deck, string name, ushort number)
        {
            return deck.AddCard(number, name);
        }
    }
}