﻿public class Program
{
    static void Main()
    {
        //create three objects for Employee
        Employee emp1 = new Employee();
        Employee emp2 = new Employee(101,"Scott","Manager");
        Employee emp3 = new Employee(102,"Khalid","Software Engineer");

        //Display Fields
        System.Console.WriteLine("First Employee");
        System.Console.WriteLine(emp1.empID);
        System.Console.WriteLine(emp1.empName);
        System.Console.WriteLine(emp1.job);
        System.Console.WriteLine();

        System.Console.WriteLine("Second Employee");
        System.Console.WriteLine(emp2.empID);
        System.Console.WriteLine(emp2.empName);
        System.Console.WriteLine(emp2.job);
        System.Console.WriteLine();

        System.Console.WriteLine("Third Employee");
        System.Console.WriteLine(emp3.empID);
        System.Console.WriteLine(emp3.empName);
        System.Console.WriteLine(emp3.job);
        System.Console.WriteLine();

        System.Console.ReadKey();
    }
}