using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, string> cache = new Dictionary<string, string>();
        List<string> order = new List<string>();

        int maxCacheSize = 3;
        void ProcessRequest(string query, string response)
        {
            Console.WriteLine($"\nЗапрос: \"{query}\"");
            if (cache.ContainsKey(query))
            {
                Console.WriteLine($"Запрос \"{query}\" уже есть в кэше. Переносим в конец очереди.");
                order.Remove(query);
                order.Add(query);
            }
            else
            {
                if (order.Count >= maxCacheSize)
                {
                    string oldestQuery = order[0];
                    Console.WriteLine($"Кэш полный. Удаляем самый старый запрос: \"{oldestQuery}\"");

                    cache.Remove(oldestQuery);
                    order.RemoveAt(0);
                }

                Console.WriteLine($"Добавляем новый запрос \"{query}\" в кэш.");
                cache.Add(query, response);
                order.Add(query);
            }

            Console.WriteLine("Текущий кэш:");
            for (int i = 0; i < order.Count; i++)
            {
                string queryInCache = order[i];
                Console.WriteLine($"  {queryInCache} -> \"{cache[queryInCache]}\"");
            }
        }

        Console.WriteLine("=== Пример работы кэша запросов (размер = 3) ===");

        ProcessRequest("погода", "Солнечно, +20°C");
        ProcessRequest("курс", "1 USD = 75 RUB");
        ProcessRequest("новости", "Главные новости дня...");
        ProcessRequest("погода", "Обновлённый прогноз: +22°C"); 
        ProcessRequest("спорт", "Результаты матчей..."); 
        ProcessRequest("новости", "Свежие новости..."); 

        Console.WriteLine("\n=== Итоговое состояние кэша ===");
        Console.WriteLine("Кэш:");
        for (int i = 0; i < order.Count; i++)
        {
            string query = order[i];
            Console.WriteLine($"  {query} — {cache[query]}");
        }
    }
}