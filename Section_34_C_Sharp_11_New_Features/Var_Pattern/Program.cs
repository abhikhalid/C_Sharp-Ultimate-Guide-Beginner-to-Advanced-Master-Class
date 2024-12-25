﻿{
    Console.WriteLine(new List<int> { 10, 20, 50 } is [10, var b, var c] && c > b); //true
}

{
    Console.WriteLine(new List<int> { 10, 20, 50 } is [10, var b and >=20, var c] && c > b); //true
}

Person person = new Person("Khalid", "Mahmud", 30);
Console.WriteLine(person is ("Khalid", "Mahmud", >= 18) and var (firstName, lastName, age) && firstName != lastName); //true

Console.ReadKey();


public record Person(string FirstName, string LastName, int Age);
