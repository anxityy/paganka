using System;

public class Counter
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Counter(string name, int value)
    {
        Name = name;
        Value = value;
    }

    public static Counter operator +(Counter counter, int increment)
    {
        return new Counter(counter.Name, counter.Value + increment);
    }

    public object this[string key]
    {
        get
        {
            if (key.ToLower() == "value")
                return Value;
            else if (key.ToLower() == "name")
                return Name;
            else
                throw new ArgumentException("Доступны только ключи 'value' и 'name'");
        }
        set
        {
            if (key.ToLower() == "value")
                Value = (int)value;
            else if (key.ToLower() == "name")
                Name = (string)value;
            else
                throw new ArgumentException("Доступны только ключи 'value' и 'name'");
        }
    }

    public override string ToString()
    {
        return $"{Name}: {Value}";
    }
}

class Program
{
    static void Main()
    {
        var c = new Counter("Счётчик", 10);
        c = c + 5;
        Console.WriteLine(c);           

        c["value"] = 20;
        Console.WriteLine(c["value"]);  

        
        Console.WriteLine(c);         

        c["name"] = "Мой счётчик";
        Console.WriteLine(c);           

        c = c + 10;
        Console.WriteLine(c);           
    }
}