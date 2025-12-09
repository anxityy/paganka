using System;

class Program
{
    static void Main()
    {
        var order1 = new Order { Id = 1001, Total = 1500.50m };
        var order2 = order1;
        order2.Total = 2000.00m;

        Console.WriteLine(order1.Total); 
    }
}

public class Order
{
    public int Id;
    public decimal Total;
}
