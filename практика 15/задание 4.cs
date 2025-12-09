using System;
using System.Collections.Generic;

public interface IAttacker
{
    void Attack();
}

public interface IHealer
{
    void Heal();
}

public class Warrior : IAttacker
{
    public string Name { get; set; }

    public Warrior(string name)
    {
        Name = name;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} (Воин) атакует мечом!");
    }
}

public class Mage : IAttacker, IHealer
{
    public string Name { get; set; }

    public Mage(string name)
    {
        Name = name;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} (Маг) бросает огненный шар!");
    }

    public void Heal()
    {
        Console.WriteLine($"{Name} (Маг) применяет исцеление!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Игроки и способности ===\n");

        Warrior warrior1 = new Warrior("Артур");
        Warrior warrior2 = new Warrior("Бьорн");
        Mage mage1 = new Mage("Мерлин");
        Mage mage2 = new Mage("Гэндальф");

        List<object> characters = new List<object> { warrior1, warrior2, mage1, mage2 };

        Console.WriteLine("1. Персонажи, которые умеют атаковать:");
        Console.WriteLine("======================================");

        int attackerCount = 0;
        foreach (var character in characters)
        {
            if (character is IAttacker attacker)
            {
                attackerCount++;
                Console.Write($"  Персонаж #{attackerCount}: ");
                attacker.Attack();
            }
        }

        Console.WriteLine($"\nВсего атакующих персонажей: {attackerCount}\n");

        Console.WriteLine("2. Персонажи, которые умеют лечить:");
        Console.WriteLine("===================================");

        int healerCount = 0;
        foreach (var character in characters)
        {
            if (character is IHealer healer)
            {
                healerCount++;
                Console.Write($"  Персонаж #{healerCount}: ");
                healer.Heal();
            }
        }

        Console.WriteLine($"\nВсего целителей: {healerCount}\n");

        Console.WriteLine("3. Подробная информация о персонажах:");
        Console.WriteLine("======================================");

        int charNumber = 1;
        foreach (var character in characters)
        {
            Console.Write($"  {charNumber}. ");

            if (character is Warrior warrior)
            {
                Console.Write($"{warrior.Name} (Воин): ");
                Console.Write("Атака - есть, ");
                Console.Write("Лечение - нет");
            }
            else if (character is Mage mage)
            {
                Console.Write($"{mage.Name} (Маг): ");
                Console.Write("Атака - есть, ");
                Console.Write("Лечение - есть");
            }

            Console.WriteLine();
            charNumber++;
        }

        Console.WriteLine("\n=== Демонстрация завершена. Нажмите Enter для выхода ===");
        Console.ReadLine(); 
    }
}