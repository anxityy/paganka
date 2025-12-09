using System;
using System.Collections.Generic;

public interface IPriceable
{
    decimal GetPrice();
}

public interface IWarrantable
{
    int GetWarrantyMonths();
}

public class Phone : IPriceable, IWarrantable
{
    private decimal price;
    private int warrantyMonths;

    public Phone(decimal price, int warrantyMonths)
    {
        this.price = price;
        this.warrantyMonths = warrantyMonths;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public int GetWarrantyMonths()
    {
        return warrantyMonths;
    }
}

public class Laptop : IPriceable
{
    private decimal price;

    public Laptop(decimal price)
    {
        this.price = price;
    }

    public decimal GetPrice()
    {
        return price;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Учет товаров в магазине ===\n");

        List<IPriceable> products = new List<IPriceable>();

        products.Add(new Phone(29999.99m, 24));
        products.Add(new Phone(15999.50m, 12));

        products.Add(new Laptop(74999.99m));
        products.Add(new Laptop(52999.00m));


        Console.WriteLine("Информация о товарах:");
        Console.WriteLine("=====================");

        decimal totalPrice = 0;
        int productNumber = 1;

        foreach (var product in products)
        {
            Console.Write($"Товар #{productNumber}: ");

            decimal price = product.GetPrice();
            totalPrice += price;
            Console.Write($"Цена: {price:C}");

            if (product is IWarrantable warrantableProduct)
            {
                int warranty = warrantableProduct.GetWarrantyMonths();
                Console.Write($", Гарантия: {warranty} месяцев");
            }
            else
            {
                Console.Write($", Гарантия: отсутствует");
            }

            Console.WriteLine();
            productNumber++;
        }


        Console.WriteLine("\nИтоговая информация:");
        Console.WriteLine("====================");
        Console.WriteLine($"Общее количество товаров: {products.Count}");
        Console.WriteLine($"Общая стоимость всех товаров: {totalPrice:C}");

        int productsWithWarranty = 0;
        foreach (var product in products)
        {
            if (product is IWarrantable)
            {
                productsWithWarranty++;
            }
        }
        Console.WriteLine($"Товаров с гарантией: {productsWithWarranty}");
        Console.WriteLine($"Товаров без гарантии: {products.Count - productsWithWarranty}");

        Console.WriteLine("\n=== Нажмите Enter для выхода ===");
        Console.ReadLine();
    }
}
