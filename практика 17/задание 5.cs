using System;

class Program
{
    static void Main()
    {
        var emp = new Employee
        {
            Name = "Пётр",
            HireDate = new DateTime(2020, 3, 15),
            Status = EmploymentStatus.Active
        };

        Console.WriteLine(emp.GetYearsWorked());

        emp.HireDate = null;
        Console.WriteLine(emp.GetYearsWorked()); 
        Console.WriteLine(emp); 
    }
}

public enum EmploymentStatus { Active, OnLeave, Terminated }

public class Employee
{
    public string Name { get; set; }
    public DateTime? HireDate { get; set; }
    public EmploymentStatus Status { get; set; }

    public int GetYearsWorked()
    {
        if (HireDate == null)
            return -1;

        DateTime today = DateTime.Today;
        int years = today.Year - HireDate.Value.Year;

        if (today.Month < HireDate.Value.Month ||
           (today.Month == HireDate.Value.Month && today.Day < HireDate.Value.Day))
        {
            years--;
        }

        return years;
    }

    public override string ToString()
    {
        string status = Status.ToString();
        string experience = HireDate.HasValue ? $"{GetYearsWorked()} лет" : "не указан";

        return $"{Name}, статус: {status}, стаж: {experience}";
    }
}