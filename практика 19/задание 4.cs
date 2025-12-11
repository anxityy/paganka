using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name;
    public int Score; 
}

class Program
{
    static void Main()
    {

        List<Student> students = new List<Student>
        {
            new Student { Name = "Анна", Score = 95 },
            new Student { Name = "Петр", Score = 95 },
            new Student { Name = "Ольга", Score = 88 },
            new Student { Name = "Иван", Score = 75 },
            new Student { Name = "Мария", Score = 75 },
            new Student { Name = "Сергей", Score = 60 },
            new Student { Name = "Елена", Score = 88 },
            new Student { Name = "Дмитрий", Score = 95 }
        };

        Dictionary<int, List<string>> scoreGroups = new Dictionary<int, List<string>>();

        foreach (var student in students)
        {
            if (!scoreGroups.ContainsKey(student.Score))
            {
                scoreGroups[student.Score] = new List<string>();
            }
            scoreGroups[student.Score].Add(student.Name);
        }

        var sortedGroups = scoreGroups.OrderByDescending(g => g.Key);

        foreach (var group in sortedGroups)
        {
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Value)}");
        }
    }
}