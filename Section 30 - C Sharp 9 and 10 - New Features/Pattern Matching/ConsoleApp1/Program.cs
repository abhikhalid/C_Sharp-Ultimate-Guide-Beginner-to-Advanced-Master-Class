﻿enum MaritalStatus
{
    Unmarried, Married
}

class Person
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }

    public MaritalStatus PersonMaritalStatus { get; set; }

    public BirthDateInfo? BirthDete { get; set; }
}

class BirthDateInfo
{
    public DateTime DateOfBirth { get; set; }
}

class Employee : Person
{
    public double? Salary { get; set; }
}

class Customer : Person
{
    public double? CustomerBalance { get; set; }
}

class Supplier: Person
{
    public double? SupplierBalance { get; set; }
}

class Manager : Employee
{

}

class Descripter
{
    public static string GetDescription(Person person)
    {
        switch (person)
        {
            case Employee emp:
            
                return $"{person.Name},{person.Age},{person.Gender},{emp.Salary}";
                break; //break statement is optional here because we have already used return keyword.

            case Customer cst:
                return $"{person.Name}, {person.Age},{person.Gender},{cst.CustomerBalance}";
                break ;

            case Supplier sup:
                return $"{person.Name},{person.Age},{person.Gender},{sup.SupplierBalance}";
                break;
            default:
                return $"{person.Name},{person.Age},{person.Gender}";

        }
    }

    //public static string GetDescription2(Person person)
    //{
    //    switch (person)
    //    {
    //        case Person p when p.Age < 20 && p.Age >= 13:
    //            return $"{p.Name} is a Teenager";
    //        case Person p when p.Age < 13:
    //            return $"{p.Name} is Child";
    //        case Person p when p.Age >= 20 && p.Age < 60:
    //            return $"{p.Name} is Adult";
    //        case Person p when p.Age >= 60:
    //            return $"{p.Name} is a senior citizen";
    //        default:
    //            return $"{person.Name} is a person";
    //    }
    //}

    //public static string GetDescription2(Person person)
    //{
    //    string result = person switch
    //    {
    //        Person p when p.Age < 13 => $"{p.Name} is Child",
    //        Person p when p.Age < 20 && p.Age >= 13 => $"{p.Name} is a Teenager",
    //        Person p when p.Age >= 20 && p.Age < 60 => $"{p.Name} is Adult",
    //        Person p when p.Age >= 60 => $"{p.Name} is a senior citizen",
    //        _ => $"{person.Name} is a person"
    //    };

    //    return result;
    //}

    //public static string GetDescription2(Person person)
    //{
    //    string result = person switch
    //    {
    //        //is => Relational Pattern
    //        // and or => Logical Pattern
    //        Person p when p.Age is < 13 => $"{p.Name} is Child",
    //        Person p when p.Age is < 20 and  >= 13 => $"{p.Name} is a Teenager",
    //        Person p when p.Age is >= 20 and < 60 => $"{p.Name} is Adult",
    //        //Person p when p.Age >= 60 => $"{p.Name} is a senior citizen",
    //        Person p when p.Age is >= 60 and not (100 or 200) => $"{p.Name} is a senior citizen",
    //        Person p when p.Age is 100 or 200 => $"{p.Name} is Centenarian",
    //        _ => $"{person.Name} is a person"
    //    };

    //    return result;
    //}

    public static string GetDescription2(Person person)
    {
        string result = person switch
        {
            Person {Age: < 13 } p => $"{p.Name} is Child",
            Person {Age: < 20 and >= 13 } p => $"{p.Name} is a Teenager",
            Person {Age: >= 20 and < 60 } p  => $"{p.Name} is Adult",
            //Person p when p.Age >= 60 => $"{p.Name} is a senior citizen",
            Person {Age: >= 60 and not (100 or 200) } p => $"{p.Name} is a senior citizen",
            Person {Age: 100 or 200 } p => $"{p.Name} is Centenarian",
            _ => $"{person.Name} is a person"
        };

        return result;
    }

    //public static string GetDescription3(Person person)
    //{
    //    // Master, Mr, Miss, Ms, Mx
    //    return person switch
    //    {
    //        Person { Gender: "Female", PersonMaritalStatus: MaritalStatus.Unmarried } => $"Miss.{person.Name}",
    //        Person { Gender: "Female", PersonMaritalStatus: MaritalStatus.Married } => $"Mrs.{person.Name}",
    //        Person { Gender: "Male", Age: < 18 } => $"Master.{person.Name}",
    //        Person { Gender: "Male", Age: >= 18 } => $"Mr {person.Name}",
    //        Person { Gender: not("Male" or "Female")} => $"Mx {person.Name}",
    //        _=> $"{person.Name}"
    //    };
    //}
    
    public static string GetDescription3(Person person)
    {
        // Master, Mr, Miss, Ms, Mx
        return person switch
        {
            //Property Pattern
            //Person { Gender: "Female", PersonMaritalStatus: MaritalStatus.Unmarried, BirthDete: { DateOfBirth: { Year: >2000} }} p => $"Miss.{p.Name}",
            
            //better syntax
            Person { Gender: "Female", PersonMaritalStatus: MaritalStatus.Unmarried, BirthDete.DateOfBirth.Year: >2000} p => $"Miss.{p.Name}",
            Person { Gender: "Female", PersonMaritalStatus: MaritalStatus.Married} p => $"Mrs.{person.Name}",
            Person { Gender: "Male", Age:<18}p => $"Master.{person.Name}",
            Person { Gender: "Male", Age:>=18}p => $"Mr.{person.Name}",
            Person { Gender: not("Male" or "Female")} p => $"Mx.{person.Name}",
            _ => $"{person.Name}"
        };
    }
}

class Program
{
    static void Main()
    {
        Manager manager = new Manager()
        {
            Name = "John",
            Gender = "Male",
            Age = 10,
            Salary = 3000,
            PersonMaritalStatus = MaritalStatus.Married,
            BirthDete = new BirthDateInfo() { DateOfBirth = DateTime.Parse("2002-01-01") }
        };

        Customer customer = new Customer()
        {
            Name = "Smith",
            Gender = "Male",
            Age = 30,
            CustomerBalance = 1000,
            PersonMaritalStatus = MaritalStatus.Unmarried,

        };

        //Console.WriteLine(Descripter.GetDescription(manager));
        //Console.WriteLine(Descripter.GetDescription(customer));
        //Console.WriteLine(Descripter.GetDescription2(manager));
        Console.WriteLine(Descripter.GetDescription3(manager));

        Console.ReadKey();
    }
}