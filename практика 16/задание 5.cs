using System;

class Program
{
    static void Main()
    {
        var v1 = new Vector(1, 2, 3);
        var v2 = new Vector(4, 5, 6);

        Console.WriteLine(v1 * v2); 
        v1[1] = 10;
        Console.WriteLine(v1);     
    }
}

public class Vector
{
    private double[] components;

    public Vector(double x, double y, double z)
    {
        components = new double[3] { x, y, z };
    }

    public double this[int index]
    {
        get
        {
            if (index >= 0 && index < 3)
                return components[index];
            throw new IndexOutOfRangeException("Индекс должен быть 0, 1 или 2");
        }
        set
        {
            if (index >= 0 && index < 3)
                components[index] = value;
            else
                throw new IndexOutOfRangeException("Индекс должен быть 0, 1 или 2");
        }
    }

    public static double operator *(Vector v1, Vector v2)
    {
        return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
    }

    
    public override string ToString()
    {
        return $"[{components[0]}, {components[1]}, {components[2]}]";
    }
}