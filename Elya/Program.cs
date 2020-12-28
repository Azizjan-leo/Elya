using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elya
{
    public class Animal
    {
        public int Age { get; set; }

        // для десериализации
        public Animal()
        {
        }

        public Animal(int age) => Age = age;

        public virtual string GetVoice()
        {
            return "I have no voice";
        }
    }

    public class Cat : Animal
    {
        // для десериализации
        public Cat()
        {
        }

        public Cat(int age) : base(age)
        {
        }

        public override string GetVoice()
        {
            return "Meow";
        }
    }

    public static class Program
    {
        private static void ToXml(Animal animal)
        {
            // сохранение данных
            using var fs = new FileStream("Elya2.xml", FileMode.OpenOrCreate);
            var x = new XmlSerializer(typeof(Animal));
            x.Serialize(fs, animal);
        }

        private static Animal FromXml()
        {
            using var fs = new FileStream("Elya2.xml", FileMode.OpenOrCreate);
            var x = new XmlSerializer(typeof(Animal));
            var animal = (Animal) x.Deserialize(fs);
            return animal;
        }

        private static async Task ToJson(Animal animal)
        {
            await using var fs = new FileStream("Elya.json", FileMode.OpenOrCreate);
            await JsonSerializer.SerializeAsync(fs, animal);
        }

        private static async Task<Animal> FromJson()
        {
            await using var fs = new FileStream("Elya.json", FileMode.OpenOrCreate);
            var animal = await JsonSerializer.DeserializeAsync<Animal>(fs);
            return animal;
        }

        private static void Main()
        {
            var animal = new Animal(1);
            var cat = new Cat(2);

            Console.WriteLine($"Animal's age bf serializing: {animal.Age}");
            ToXml(animal);

            var restoredAnimal = FromXml();
            Console.WriteLine($"Restored animal's age: {restoredAnimal.Age}");
        }
    }
}