using System;
using System.Collections.Generic;
using System.Linq;
using BankingApp.Models;

namespace BankingApp.Services
{
    public class BankingService
    {
        private static List<User> _users = new List<User>();
        private static List<Account> _accounts = new List<Account>();
        private static List<Transaction> _transactions = new List<Transaction>();
        private static List<Beneficiary> _beneficiaries = new List<Beneficiary>();

        public BankingService()
        {
            // Initialize with some dummy data
            if (!_users.Any())
            {
                var user1 = new User
                {
                    Id = 1,
                    Username = "john",
                    Password = "password123",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@example.com",
                    PhoneNumber = "1234567890",
                    CreatedDate = DateTime.Now
                };

                var account1 = new Account
                {
                    Id = 1,
                    AccountNumber = "1234567890",
                    AccountType = "Savings",
                    Balance = 10000,
                    CreatedDate = DateTime.Now,
                    UserId = 1
                };

                var account2 = new Account
                {
                    Id = 2,
                    AccountNumber = "0987654321",
                    AccountType = "Current",
                    Balance = 5000,
                    CreatedDate = DateTime.Now,
                    UserId = 1
                };

                user1.Accounts.Add(account1);
                user1.Accounts.Add(account2);

                _users.Add(user1);
                _accounts.Add(account1);
                _accounts.Add(account2);

                // Add some sample transactions
                AddTransaction(account1, "Deposit", 10000, "Initial deposit");
                AddTransaction(account2, "Deposit", 5000, "Initial deposit");
            }
        }

        private void AddTransaction(Account account, string type, decimal amount, string description, string toAccountNumber = null)
        {
            var transaction = new Transaction
            {
                Id = _transactions.Count + 1,
                TransactionType = type,
                Amount = amount,
                TransactionDate = DateTime.Now,
                Description = description,
                AccountId = account.Id,
                ToAccountNumber = toAccountNumber,
                Status = "Completed"
            };
            _transactions.Add(transaction);
        }

        public User GetUser(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public bool UpdateUserProfile(int userId, User updatedUser)
        {
            var user = GetUser(userId);
            if (user == null) return false;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            return true;
        }

        public User AuthenticateUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public List<Account> GetUserAccounts(int userId)
        {
            return _accounts.Where(a => a.UserId == userId).ToList();
        }

        public Account GetAccount(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public bool TransferAmount(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = GetAccount(fromAccountNumber);
            
            if (fromAccount == null || fromAccount.Balance < amount)
                return false;

            // Check if the destination account exists in our system
            var toAccount = GetAccount(toAccountNumber);
            
            // Deduct amount from source account
            fromAccount.Balance -= amount;
            AddTransaction(fromAccount, "Debit", amount, $"Transfer to {toAccountNumber}", toAccountNumber);

            // If the destination account exists in our system, add the amount
            if (toAccount != null)
            {
                toAccount.Balance += amount;
                AddTransaction(toAccount, "Credit", amount, $"Transfer from {fromAccountNumber}", fromAccountNumber);
            }

            return true;
        }

        public bool AddBeneficiary(Beneficiary beneficiary)
        {
            beneficiary.Id = _beneficiaries.Count + 1;
            beneficiary.AddedDate = DateTime.Now;
            _beneficiaries.Add(beneficiary);
            return true;
        }

        public List<Beneficiary> GetUserBeneficiaries(int userId)
        {
            return _beneficiaries.Where(b => b.UserId == userId).ToList();
        }

        public List<Transaction> GetAccountTransactions(int accountId)
        {
            return _transactions.Where(t => t.AccountId == accountId)
                              .OrderByDescending(t => t.TransactionDate)
                              .ToList();
        }

        public decimal GetAccountBalance(int accountId)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == accountId);
            return account?.Balance ?? 0;
        }

        public List<Transaction> GetAccountStatement(int accountId, DateTime startDate, DateTime endDate)
        {
            return _transactions.Where(t => t.AccountId == accountId &&
                                          t.TransactionDate >= startDate &&
                                          t.TransactionDate <= endDate)
                              .OrderByDescending(t => t.TransactionDate)
                              .ToList();
        }
    }
} 