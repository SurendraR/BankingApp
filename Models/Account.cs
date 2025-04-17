using System;
using System.Collections.Generic;

namespace BankingApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
} 