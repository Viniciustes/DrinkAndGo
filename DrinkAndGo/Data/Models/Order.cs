﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DrinkAndGo.Data.Models
{
    public class Order
    {
        public Order() { }

        public Order(string firstName, string lastName, string addressLine1, string addressLine2, string zipCode, string state, string country, string phoneNumber, string email, string city)
        {
            OrderId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            ZipCode = zipCode;
            State = state;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Email = email;
            OrderPlaced = DateTime.Now;
        }

        [Key]
        public Guid OrderId { get; private set; }
        public List<OrderDetail> OrderLines { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string ZipCode { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public decimal OrderTotal { get; private set; }
        public DateTime OrderPlaced { get; private set; }
    }
}