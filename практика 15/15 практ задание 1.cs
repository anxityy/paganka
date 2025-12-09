using System;

public interface яумею
{
    void Work();
}

public interface IRechargeable
{
    void Recharge();
}

public class Robot : яумею, IRechargeable
{
    public string Name { get; private set; }
    public int Energy { get; private set; }

    public Robot(string name)
    {
        Name = name;
        Energy = 100; 
    }

    public void Work()
    {
        if (Energy >= 20)
        {
            Energy -= 20;
        }
        else
        {
            Energy = 0;
        }

        Console.WriteLine($"{Name} поработал. Текущая энергия: {Energy}");
    }

    public void Recharge()
    {
        if (Energy <= 50)
        {
            Energy += 50;
        }
        else
        {
            Energy = 100;
        }

        Console.WriteLine($"{Name} зарядился. Текущая энергия: {Energy}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Robot robot = new Robot("мегамозг");

        Console.WriteLine("=== Демонстрация работы робота ===\n");

        Console.WriteLine("1. Робот работает первый раз:");
        robot.Work();

        Console.WriteLine("\n2. Робот работает второй раз:");
        robot.Work();

        Console.WriteLine("\n3. Робот заряжается:");
        robot.Recharge();

        Console.WriteLine("\n4. Робот работает третий раз:");
        robot.Work();

        Console.WriteLine("\n=== Программа завершена ===");
    }
}