using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> stock = new Dictionary<string, int>();
        List<string> sold = new List<string>();

        stock.Add("Молоко", 15);
        stock.Add("Хлеб", 10);
        stock.Add("Яйца", 20);
        stock.Add("Сахар", 5);
        stock.Add("Масло", 8);
        stock.Add("Соль", 12);
        SellItem("Молоко", stock, sold);
        SellItem("Молоко", stock, sold);
        SellItem("Хлеб", stock, sold);
        SellItem("Яйца", stock, sold);
        SellItem("Вода", stock, sold); 

        Console.WriteLine("Остатки:");
        foreach (var item in stock)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }

        Console.WriteLine();
        Console.WriteLine("Продано:");
        var soldStats = sold.GroupBy(item => item)
                            .Select(g => new { Name = g.Key, Count = g.Count() })
                            .OrderBy(x => x.Name);

        foreach (var stat in soldStats)
        {
            Console.WriteLine($"{stat.Name} — {stat.Count} {GetTimesWord(stat.Count)}");
        }
    }

    static void SellItem(string itemName, Dictionary<string, int> stock, List<string> sold)
    {
        if (stock.ContainsKey(itemName) && stock[itemName] > 0)
        {
            stock[itemName]--;
            sold.Add(itemName);
            Console.WriteLine($"Продано: {itemName}");
        }
        else
        {
            Console.WriteLine("Товара нет в наличии");
        }
    }

    static string GetTimesWord(int count)
    {
        if (count % 10 == 1 && count % 100 != 11) return "раз";
        if (count % 10 >= 2 && count % 10 <= 4 && (count % 100 < 10 || count % 100 >= 20)) return "раза";
        return "раз";
    }
}