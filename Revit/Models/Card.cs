namespace Revit.Models
{
    public class Card
    {
        public ushort Number { get; set; }
        public string Name { get; set; }

        public Card(ushort number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}