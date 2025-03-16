using System;
using Decorator;
using Decorator.Decorators;
using Decorator.Heroes;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 

        IHero hero1 = new Warrior();
        hero1 = new Armor(hero1);
        hero1 = new Sword(hero1);
        hero1 = new RingOfPower(hero1);
        PrintHeroInfo(hero1);

        IHero hero2 = new Mage();
        hero2 = new WitcherPotion(hero2);
        hero2 = new Amulet(hero2);
        hero2 = new RingOfPower(hero2);
        PrintHeroInfo(hero2);

        IHero hero3 = new Paladin();
        hero3 = new Sword(hero3);
        hero3 = new WitcherPotion(hero3);
        hero3 = new Armor(hero3);
        PrintHeroInfo(hero3);
    }

    static void PrintHeroInfo(IHero hero)
    {
        Console.ForegroundColor = ConsoleColor.Cyan; 
        Console.WriteLine("====================================");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Hero: {hero.GetDescription()}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Power: {hero.GetPower()}");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================");
        Console.ResetColor(); 
        Console.WriteLine();
    }
}