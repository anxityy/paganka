using System;

class Program
{
    static void Main()
    {
        var book = new Book();
        book[0] = "Введение";
        book[1] = "Глава 1";

        Console.WriteLine(book[0]); 
        Console.WriteLine(book);   
                                   
    }
}

public class Book
{
    private string[] chapters = new string[100]; 

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= chapters.Length)
                throw new IndexOutOfRangeException($"Индекс должен быть от 0 до {chapters.Length - 1}");

            return chapters[index];
        }
        set
        {
            if (index < 0 || index >= chapters.Length)
                throw new IndexOutOfRangeException($"Индекс должен быть от 0 до {chapters.Length - 1}");

            chapters[index] = value;
        }
    }

    public override string ToString()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int chapterNumber = 1;

        for (int i = 0; i < chapters.Length; i++)
        {
            if (!string.IsNullOrEmpty(chapters[i]))
            {
                sb.AppendLine($"{chapterNumber}. {chapters[i]}");
                chapterNumber++;
            }
        }

        return sb.ToString();
    }
}