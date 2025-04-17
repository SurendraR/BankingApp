using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BankingApp.Models;
using BankingApp.Services;
using Microsoft.AspNetCore.Http;

namespace BankingApp.Controllers
{
    public class BeneficiaryController : Controller
    {
        private readonly BankingService _bankingService;

        public BeneficiaryController()
        {
            _bankingService = new BankingService();
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var beneficiaries = _bankingService.GetUserBeneficiaries(userId.Value);
            return View(beneficiaries);
        }

        public IActionResult Create()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Beneficiary beneficiary)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                beneficiary.UserId = userId.Value;
                if (_bankingService.AddBeneficiary(beneficiary))
                {
                    TempData["Message"] = "Beneficiary added successfully!";
                    return RedirectToAction("Index");
                }
            }

            TempData["Error"] = "Failed to add beneficiary. Please check the details.";
            return View(beneficiary);
        }
    }
} 