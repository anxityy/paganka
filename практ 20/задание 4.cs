using System;

class Program
{
    class HeroIsDeadException : Exception
    {
        public HeroIsDeadException(int health) : base($"Герой погиб! Здоровье стало {health}") { }
    }

    class Game
    {
        private int health = 100;

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0) throw new HeroIsDeadException(health);
            Console.WriteLine($"Выжил! Здоровье: {health}");
        }
    }

    static void Main()
    {
        var game = new Game();

        Console.WriteLine("Здоровье: 100");

        Console.Write("Получаем урон: 150 -> ");
        try { game.TakeDamage(150); } catch (Exception e) { Console.WriteLine(e.Message); }

        Console.Write("\nПолучаем урон: 50 -> ");
        try { game.TakeDamage(50); } catch (Exception e) { Console.WriteLine(e.Message); }
    }
}