﻿using CityBank.DataAccesLayer.DALContracts;
using CityBank.Entities;
using CityBank.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityBank.DataAccesLayer
{
    /// <summary>
    /// Represents DAL for bank customers
    /// </summary>
    public class CustomerDataAccessLayer : ICustomerDataAccessLayer
    {
        #region Fields
        private static List<Customer> _customers;
        #endregion 

        #region Constructors
        static CustomerDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion


        #region Properties
        /// <summary>
        /// Represents source customers collection.
        /// </summary>
        public static List<Customer> Customers
        {
            set => _customers = value;
            get => _customers;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a new customer to the existing list.
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns Guid of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //generate new Guid
                customer.CustomerID = Guid.NewGuid();

                //add Customer
                Customers.Add(customer);

                return customer.CustomerID;
            }
            catch(CustomerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes an existing customer based on CustomerID
        /// </summary>
        /// <param name="customerId">CustomerID to delete</param>
        /// <returns></returns>
        public bool DeleteCustomer(Guid customerId)
        {
            try
            {
                //delete customer by CustomerID
                if (Customers.RemoveAll(item => item.CustomerID == customerId) > 0)
                {
                    return true; //indicates one or more customers are deleted
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer> GetCustomers()
        {
            try
            {
                //create a new customers list
                List<Customer> customerList = new List<Customer>();

                //copy all customers from the source collection into the newCustomers list
                Customers.ForEach(item => customerList.Add(item.Clone() as Customer));

                return customerList;
            }
            catch (CustomerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns list of customers that are matching with specified criteria.
        /// </summary>
        /// <param name="predicate">Lamda expression with condition</param>
        /// <returns>List of matching customers.</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //create a new customers list
                List<Customer> customersList = new List<Customer>();

                //filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);

                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));

                return customersList;
            }
            catch(CustomerException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates an existing customer's details
        /// </summary>
        /// <param name="customer">Customer object with updated details</param>
        /// <returns>Determines whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find exisitng customer by CustomerID
                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                //update all details of customer
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.LandMark = customer.LandMark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(CustomerException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}