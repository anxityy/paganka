using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
       
        List<string> names = new List<string> { "Анна", "Пётр", "Анна", "Ольга", "Пётр", "Иван" };

        Console.WriteLine("Входной список:");
        foreach (var name in names)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();

        List<string> uniqueNames = RemoveDuplicates(names);

        Console.WriteLine("Список без дубликатов (с сохранением порядка):");
        foreach (var name in uniqueNames)
        {
            Console.Write(name + " ");
        }
    }

    static List<string> RemoveDuplicates(List<string> inputList)
    {
        List<string> result = new List<string>();

        foreach (string name in inputList)
        {
           
            if (!result.Contains(name))
            {
                result.Add(name);
            }
        }

        return result;
    }
}