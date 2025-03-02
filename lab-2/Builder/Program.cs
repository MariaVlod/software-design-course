
using Builder;
using System;

class Program
{
    static void Main(string[] args)
    {
        Director director = new Director();

        HeroBuilder heroBuilder = new HeroBuilder();
        Hero legolas = director.CreateLegolas(heroBuilder);
        legolas.DisplayInfo();

        Console.WriteLine("\n-----------------------------\n");

        EnemyBuilder enemyBuilder = new EnemyBuilder();
        Enemy negan = director.CreateNegan(enemyBuilder);
        negan.DisplayInfo();
    }
}