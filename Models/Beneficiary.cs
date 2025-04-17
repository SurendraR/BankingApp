using System;

namespace BankingApp.Models
{
    public class Beneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSC { get; set; }
        public DateTime AddedDate { get; set; }
        public int UserId { get; set; }
       // public User User { get; set; }
    }
} 