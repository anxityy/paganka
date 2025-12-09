using System;

class Program
{
    static void Main()
    {
        var c1 = new Color(255, 128, 0);
        var c2 = c1;
        c2.R = 100;

        Console.WriteLine(c1); 
        Console.WriteLine(c2); 
    }
}

public struct Color
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    
    public override string ToString()
    {
        return $"RGB({R}, {G}, {B})";
    }
}


