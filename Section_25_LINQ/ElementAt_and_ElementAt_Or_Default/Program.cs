﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Section_25_LINQ
{
    class Employee
    {
        public int EmpID { get; set; }

        public string EmpName { get; set; }

        public string Job { get; set; }

        public double Salary { get; set; }
    }

    class Program
    {
        static void Main()
        {
            //collection of objects
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    EmpID = 101,
                    EmpName = "Henry",
                    Job = "Designer",
                    Salary = 7232
                },
                 new Employee()
                {
                    EmpID = 102,
                    EmpName = "Jack",
                    Job = "Developer",
                    Salary = 4500
                },
                new Employee()
                {
                    EmpID = 103,
                    EmpName = "Gabriel",
                    Job = "Analyst",
                    Salary = 1293
                },
                new Employee()
                {
                    EmpID = 104,
                    EmpName = "William",
                    Job = "Manager",
                    Salary = 2873
                },
                new Employee()
                {
                    EmpID = 105,
                    EmpName = "Alexa",
                    Job = "Manager",
                    Salary = 6232
                },
                new Employee()
                {
                    EmpID = 105,
                    EmpName = "Siri",
                    Job = "Manager",
                    Salary = 6232
                },
            };

            //ElementAt
            Employee resultEmp = employees.Where(emp => emp.Job == "Manager").ElementAt(1);
            //Employee resultEmp = employees.Where(emp => emp.Job == "Manager").ElementAt(4);
            
            
            //ElementAtOrDefault
            Employee resultEmp2 = employees.Where(emp => emp.Job == "Manager").ElementAtOrDefault(4);


            if(resultEmp2 != null)
            {
                Console.WriteLine(resultEmp2.EmpID+","+resultEmp2.EmpName+","+resultEmp2.Job);
            }
            else
            {
                Console.WriteLine("");
            }


            Console.ReadKey();
        }
    }
}
