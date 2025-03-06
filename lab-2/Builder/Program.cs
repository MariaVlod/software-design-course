
using Builder;
using System;

class Program
{
    static void Main(string[] args)
    {// Створення будівельників
        var heroBuilder = new HeroBuilder();
        var enemyBuilder = new EnemyBuilder();
        var director = new Director(heroBuilder);

        var hero = (Hero)director.CreateCharacter();
        hero.DisplayInfo();

        Console.WriteLine("\n-----------------------------\n");

        director.ChangeBuilder(enemyBuilder);

        var enemy = (Enemy)director.CreateEvilCharacter();
        enemy.DisplayInfo();
    }
}