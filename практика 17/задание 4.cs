using System;

class Program
{
    static void Main()
    {
        var w1 = new Weather { City = "Москва", Temperature = 22.5 };
        var w2 = new Weather { City = "Сочи", Temperature = null };

        Console.WriteLine(w1); 
        Console.WriteLine(w2); 
        Console.WriteLine(w2.Temperature ?? -999); 
    }
}

public struct Weather
{
    public string City { get; set; }
    public double? Temperature { get; set; }

    public override string ToString()
    {
        if (Temperature.HasValue)
            return $"{City}: {Temperature}°C";
        else
            return $"{City}: Нет данных";
    }
}