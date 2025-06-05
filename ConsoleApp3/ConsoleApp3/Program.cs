using System;

interface Ianimal
{
    void Sound();
}

// Generic base class with chainable setters returning the derived type T
class Animal<T> where T : Animal<T>
{
    protected int age;
    protected string name;

    public T AgeSetter(int age)
    {
        this.age = age;
        return (T)this; // Return derived type for chaining
    }

    public T NameSetter(string name)
    {
        this.name = name;
        return (T)this; // Return derived type for chaining
    }

    public T InformationObservation()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        return (T)this; // Return derived type for chaining
    }
}

// Cat inherits Animal<Cat> and implements Ianimal
class Cat : Animal<Cat>, Ianimal
{
    public void Sound()
    {
        Console.WriteLine("Meowwww");
    }
}

// Dog inherits Animal<Dog> and implements Ianimal
class Dog : Animal<Dog>, Ianimal
{
    public void Sound()
    {
        Console.WriteLine("Barking");
    }
}

// Generic factory to create new instances of T (which implements Ianimal and has a parameterless constructor)
class AnimalFactory<T> where T : Ianimal, new()
{
    public static T Creator()
    {
        return new T();
    }
}

class Program
{
    static void Main()
    {
        // Using interface reference, but casting to concrete type to access chainable methods
        Ianimal c = AnimalFactory<Cat>.Creator();
        ((Cat)c).AgeSetter(1).NameSetter("hash").InformationObservation().Sound();

        Ianimal d = AnimalFactory<Dog>.Creator();
        ((Dog)d).NameSetter("felfel").AgeSetter(5).InformationObservation().Sound();
    }

}
