using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BankingApp.Models;
using BankingApp.Services;
using Microsoft.AspNetCore.Http;

namespace BankingApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankingService _bankingService;

        public AccountController()
        {
            _bankingService = new BankingService();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _bankingService.AuthenticateUser(username, password);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var accounts = _bankingService.GetUserAccounts(userId.Value);
            return View(accounts);
        }

        public IActionResult Transfer()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var accounts = _bankingService.GetUserAccounts(userId.Value);
            var beneficiaries = _bankingService.GetUserBeneficiaries(userId.Value);
            ViewBag.Beneficiaries = beneficiaries;
            return View(accounts);
        }

        [HttpPost]
        public IActionResult Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            if (_bankingService.TransferAmount(fromAccountNumber, toAccountNumber, amount))
            {
                TempData["Message"] = "Transfer successful!";
            }
            else
            {
                TempData["Error"] = "Transfer failed. Please check the account details and balance.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Transactions(string accountNumber)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var account = _bankingService.GetAccount(accountNumber);
            if (account == null || account.UserId != userId.Value)
            {
                return NotFound();
            }

            var transactions = _bankingService.GetAccountTransactions(account.Id);
            ViewBag.AccountNumber = accountNumber;
            return View(transactions);
        }

        public IActionResult Statement(string accountNumber, DateTime? startDate, DateTime? endDate)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var account = _bankingService.GetAccount(accountNumber);
            if (account == null || account.UserId != userId.Value)
            {
                return NotFound();
            }

            var transactions = _bankingService.GetAccountTransactions(account.Id);
            
            if (startDate.HasValue && endDate.HasValue)
            {
                transactions = transactions.Where(t => t.TransactionDate >= startDate.Value && t.TransactionDate <= endDate.Value).ToList();
            }

            ViewBag.AccountNumber = accountNumber;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View(transactions);
        }

        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            var user = _bankingService.GetUser(userId.Value);
            return View(user);
        }

        [HttpPost]
        public IActionResult UpdateProfile(User updatedUser)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login");
            }

            if (_bankingService.UpdateUserProfile(userId.Value, updatedUser))
            {
                TempData["Message"] = "Profile updated successfully!";
            }
            else
            {
                TempData["Error"] = "Failed to update profile.";
            }

            return RedirectToAction("Profile");
        }
    }
} 