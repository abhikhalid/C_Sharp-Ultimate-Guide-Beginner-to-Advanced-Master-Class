﻿class Program
{
    public static void Main()
    {
        //create object of generic clsss
        User<int> user1 = new User<int>();
        User<bool> user2 = new User<bool>();

        //set value into generic field
        user1.RegistrationStatus = 1234;
        user2.RegistrationStatus = false;

        System.Console.WriteLine(user1.RegistrationStatus);

        System.Console.ReadKey();
    }
}