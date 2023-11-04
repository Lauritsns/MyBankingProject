using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using MyBankingProject.DBAcces;
using MyBankingProject.Models;
using System.Diagnostics;

namespace MyBankingProject.Controllers
{
    public class HomeController : Controller
    {
        
        private BankingContext bankingContext = new BankingContext();


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
            return View();
        }

    }
}