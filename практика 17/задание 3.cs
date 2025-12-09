using System;
using System.IO;

class Program
{
    static void Main()
    {
        var f = new File { Permissions = FileAccess.Read | FileAccess.Write };
        Console.WriteLine(f.CanRead());  
        Console.WriteLine(f.CanWrite()); 
    }
}

public struct File
{
    public FileAccess Permissions { get; set; }

    public bool CanRead()
    {
        return (Permissions & FileAccess.Read) == FileAccess.Read;
    }

    public bool CanWrite()
    {
        return (Permissions & FileAccess.Write) == FileAccess.Write;
    }
}