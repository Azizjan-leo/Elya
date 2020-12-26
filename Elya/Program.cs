using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Animal
{
    public virtual int Age { get; init; }
    // для десериализации
    public Animal()
    {
        Age = 0;
    }
    public Animal(int age)
    {
        Age = age;
    }
    public virtual string GetVoice()
    {
        return "I have no voice";
    }
}

public class Cat : Animal
{
    // для десериализации
    private Cat() : base(0) { }
    public Cat(int age) : base(age)
    {
    }
    public override string GetVoice()
    {
        return "Meow";
    }
}

class Program
{
    static void ToXML(Animal animal)
    {
        // сохранение данных
        using (FileStream fs = new FileStream("Elya2.xml", FileMode.OpenOrCreate))
        {
            XmlSerializer x = new XmlSerializer(typeof(Animal));
            x.Serialize(fs, animal);
        }
    }
    static Animal FromXML()
    {
        using (FileStream fs = new FileStream("Elya2.xml", FileMode.OpenOrCreate))
        {
            XmlSerializer x = new XmlSerializer(typeof(Animal));
            var animal = (Animal)x.Deserialize(fs);
            return animal;
        }
    }
    async Task ToJson(Animal animal)
    {
        using (FileStream fs = new FileStream("Elya.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<Animal>(fs, animal);
        }
    }
    async Task<Animal> FromJson()
    {
        using (FileStream fs = new FileStream("Elya.json", FileMode.OpenOrCreate))
        {
            Animal animal = await JsonSerializer.DeserializeAsync<Animal>(fs);
            return animal;
        }
    }

    static async Task Main(string[] args)
    {
        Animal animal = new Animal(1);
        Cat cat = new Cat(2);
       
        Console.WriteLine($"Animal's age bf serializing: {animal.Age}");
        ToXML(animal);

        Animal restoredAnimal = FromXML();
        Console.WriteLine($"Restored animal's age: {restoredAnimal.Age}");
    }
}
