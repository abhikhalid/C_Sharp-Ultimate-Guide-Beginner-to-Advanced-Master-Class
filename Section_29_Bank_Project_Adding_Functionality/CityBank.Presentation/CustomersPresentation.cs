﻿using CityBank.BusinessLogicLayer;
using CityBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBank.Presentation
{
    static class CustomersPresentation
    {
        internal static void AddCustomer()
        {
            try
            {
                //create object of Customer
                Customer customer = new Customer();

                //read all details from the user
                Console.WriteLine("\n******ADD CUSTOMER******");
                Console.Write("Customer Name:");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address:");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark:");
                customer.LandMark = Console.ReadLine();
                Console.Write("City:");
                customer.City = Console.ReadLine();
                Console.Write("Country");
                customer.Country = Console.ReadLine();
                Console.WriteLine("Mobile:");
                customer.Mobile = Console.ReadLine();

                //Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer);

                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newGuid);

                if(matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added.\n");
                }
                else
                {
                    Console.WriteLine("Customer Not added");
                }

                Console.WriteLine("Customer Added\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewCustomers()
        {
            try
            {
                //Create BL object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
            
                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();

                Console.WriteLine("\n******ALL CUSTOMERS*****");

                foreach(var item in allCustomers)
                {
                    Console.WriteLine("Customer Code: " + item.CustomerCode);
                    Console.WriteLine("Customer Name: " + item.CustomerName);
                    Console.WriteLine("Address: " + item.Address);
                    Console.WriteLine("Landmark : " + item.LandMark);
                    Console.WriteLine("City : " + item.City);
                    Console.WriteLine("Country: " + item.Country);
                    Console.WriteLine("Mobile : " + item.Mobile);
                    Console.WriteLine();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

        }
    }
}
