namespace Revit.Models
{
    public class Card
    {
        public ushort Number { get; init; }
        public string Name { get; init; }

        public Card(ushort number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}