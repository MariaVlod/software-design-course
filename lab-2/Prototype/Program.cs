using Prototype;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating the virus family...");
        Virus grandfather = new Virus(1.5, 10, "Grandfather Virus", "Alpha");
        Virus father = new Virus(1.2, 5, "Father Virus", "Beta");
        Virus son1 = new Virus(0.8, 2, "Son Virus 1", "Gamma");
        Virus son2 = new Virus(0.9, 3, "Son Virus 2", "Gamma");

        grandfather.AddChild(father);
        father.AddChild(son1);
        father.AddChild(son2);

        Console.WriteLine("\nOriginal Virus Family:");
        grandfather.DisplayInfo();
        
        Virus clonedFather = (Virus)father.Clone();
        Console.WriteLine("\nCloned Virus Family:");
        clonedFather.DisplayInfo();
        
        Console.WriteLine("\nModifying the cloned family...");
        clonedFather.Name = "Cloned Father Virus";
        clonedFather.Children[0].Name = "Cloned Son Virus 1";

        Console.WriteLine("\nOriginal Virus Family After Modification:");
        grandfather.DisplayInfo();

        Console.WriteLine("\nCloned Virus Family After Modification:");
        clonedFather.DisplayInfo();

        Console.WriteLine("\nProgram finished.");
    }
}