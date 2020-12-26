using System;

public class Animal
{
    public virtual string GetVoice()
    {
        return "I have no voice";
    }
}

public class Cat : Animal
{
    public override string GetVoice()
    {
        return "Meow";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal animal = new Animal();
        Cat cat = new Cat();

        Console.WriteLine($"An animal voice: {animal.GetVoice()}\nA cat voice: {cat.GetVoice()}");
    }
}
