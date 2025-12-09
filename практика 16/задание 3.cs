using System;

class Program
{
    static void Main()
    {
        var t1 = new Temperature(25);
        var t2 = new Temperature(30);

        Console.WriteLine(t1);     
        Console.WriteLine(t2 > t1); 
        Console.WriteLine(t1 == new Temperature(25));
    }
}

public class Temperature
{
    public double Celsius { get; }

    public Temperature(double celsius)
    {
        Celsius = celsius;
    }

    public static bool operator >(Temperature left, Temperature right)
    {
        return left.Celsius > right.Celsius;
    }

    public static bool operator <(Temperature left, Temperature right)
    {
        return left.Celsius < right.Celsius;
    }

    public static bool operator ==(Temperature left, Temperature right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;

        return left.Celsius == right.Celsius;
    }

    public static bool operator !=(Temperature left, Temperature right)
    {
        return !(left == right);
    }

    public override bool Equals(object obj)
    {
        if (obj is Temperature other)
            return this.Celsius == other.Celsius;
        return false;
    }

    public override int GetHashCode()
    {
        return Celsius.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Celsius}°C";
    }
}