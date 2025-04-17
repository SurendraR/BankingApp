using System;

namespace BankingApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string ToAccountNumber { get; set; }
        public string Status { get; set; }
    }
} 