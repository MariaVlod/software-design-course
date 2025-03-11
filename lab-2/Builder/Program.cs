
using Builder;
using System;

class Program
{
    static void Main()
    {
        var heroBuilder = new HeroBuilder();
        var enemyBuilder = new EnemyBuilder();

        var director = new Director(heroBuilder);
        Character hero = director.CreateCharacter();

        director.SetBuilder(enemyBuilder);
        Character enemy = director.CreateEvilCharacter();

        Console.WriteLine("Hero:");
        hero.ShowInfo();

        Console.WriteLine("Enemy:");
        enemy.ShowInfo();
    }
}