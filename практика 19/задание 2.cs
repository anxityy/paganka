using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текст:");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Текст не введен.");
            return;
        }

        string[] words = input.ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string trimmedWord = word.Trim();
            if (string.IsNullOrEmpty(trimmedWord))
                continue;

            if (wordFrequency.ContainsKey(trimmedWord))
            {
                wordFrequency[trimmedWord]++;
            }
            else
            {
                wordFrequency[trimmedWord] = 1;
            }
        }

        Console.WriteLine("\nРезультат (слово — частота):");
        foreach (var pair in wordFrequency)
        {
            Console.WriteLine($"{pair.Key} — {pair.Value}");
        }
    }
}
