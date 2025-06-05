using System;

interface Ianimal
{
    void Sound();
}


class Animal<T> where T : Animal<T>
{
    protected int age;
    protected string name;

    public T AgeSetter(int age)
    {
        this.age = age;
        return (T)this; 
    }

    public T NameSetter(string name)
    {
        this.name = name;
        return (T)this; 
    }

    public T InformationObservation()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Age: {age}");
        return (T)this; 
    }
}


class Cat : Animal<Cat>, Ianimal
{
    public void Sound()
    {
        Console.WriteLine("Meowwww");
    }
}


class Dog : Animal<Dog>, Ianimal
{
    public void Sound()
    {
        Console.WriteLine("Barking");
    }
}

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
    
        Var c = AnimalFactory<Cat>.Creator();
        c.AgeSetter(1).NameSetter("hash").InformationObservation().Sound();

        Var d = AnimalFactory<Dog>.Creator();
        d.NameSetter("felfel").AgeSetter(5).InformationObservation().Sound();
    }

}
