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
        private List<Deck> _decks = new List<Deck>();
        public DeckService(){}

        public Deck GetDeck(string name)
        {
            var deck = _decks.Where(x => x.Name == name).FirstOrDefault();

            return deck;
        }

        public OperationResult AddDeck(string name, ushort capacity)
        {
            if(_decks.Exists(x => x.Name == name))
                return new OperationResult($"The name {name} is taken.", false);
            try
            {
                Deck deck = new Deck(name, capacity);
                _decks.Add(deck);
                return new OperationResult($"The {name} deck has been successfully added!", true);
            }
            catch (Exception e)
            {
                return new OperationResult(e.Message, false);
            }
        }

        internal OperationResult AddCard(ref Deck deck, string name, ushort number)
        {
            return deck.AddCard(number, name);
        }
    }
}
