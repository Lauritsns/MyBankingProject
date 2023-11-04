using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using MyBankingProject.DBAcces;
using MyBankingProject.Models;
using System.Diagnostics;

namespace MyBankingProject.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly BankingContext bankingContext = new();
        private readonly String loginCustomer = "MinMail@gmail.com";

        public HomeController()
        {
            if (bankingContext.Accounts != null && bankingContext.Customers != null)
            {
                bankingContext.Database.EnsureDeleted();
                bool created = bankingContext.Database.EnsureCreated();
            
                if (created)
                {
                    Console.WriteLine("Databases created");
                }
            }



        }
        public IActionResult Index()
        {
            List<Customer> customers = bankingContext.Customers.Where(customer => customer.Email == loginCustomer).ToList();
            String? customerCPR = customers[0].CPR;
            String? customerName = customers[0].Name;
            try
            {
                if(customerCPR != null && customerName != null)
                {
                    List<Account> accountData = bankingContext.Accounts.Where(account => account.CPR == customerCPR).ToList();
                    ViewBag.Accounts = accountData;
                    ViewBag.CustomerName = customerName;
                }
            } catch (Exception error) { Console.WriteLine(error.StackTrace + "No logged in customer"); } 
           
            
            return View("Index");
        }
            
        }

    }
