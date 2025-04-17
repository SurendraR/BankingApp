using System;
using System.Collections.Generic;

namespace BankingApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Beneficiary> Beneficiaries { get; set; } = new List<Beneficiary>();
    }
} 