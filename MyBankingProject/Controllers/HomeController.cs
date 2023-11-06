using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Spreadsheet;
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
        private readonly String? customerCPR;
        private readonly List<String>? accountNumbers;
        private readonly List<Customer> customers;
        private readonly List<Account> accountData;
        private readonly List<Transaction> transactions;

        public HomeController()
        {
            if (bankingContext.Accounts != null && bankingContext.Customers != null)
            {
                
                bool created = bankingContext.Database.EnsureCreated();
            
                if (true)
                {
                    
                    transactions = new List<Transaction>();
                    customers = bankingContext.Customers.Where(customer => customer.Email == loginCustomer).ToList();
                    customerCPR = customers[0].CPR;
                    accountData = bankingContext.Accounts.Where(account => account.CPR == customerCPR).ToList();
                    Console.WriteLine("Databases created");
                }
            }



        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            String? customerName = customers[0].Name;
            try
            {
                if(customerCPR != null && customerName != null)
                {
                    ViewBag.Accounts = bankingContext.Accounts.Where(account => account.CPR == customerCPR).ToList();
                    ViewBag.CustomerName = customerName;
                    ViewBag.Header = "Home";
                }
            } catch (Exception error) { Console.WriteLine(error.StackTrace + "No logged in customer"); } 
           
            
            return View("Index");
        }

        [HttpGet]
        [Route("/Transactions")]
        public ActionResult Transactions()
        {
            transactions.Clear();
            ViewBag.CustomerName = customers[0].Name;
            ViewBag.Accounts = bankingContext.Accounts.Where(account => account.CPR == customerCPR).ToList();
            foreach (var element in accountData)
            {
                transactions.AddRange(bankingContext.Transactions.Where(transaction => transaction.SenderAccountNumber == element.AccountNumber).ToList());
                transactions.AddRange(bankingContext.Transactions.Where(transaction => transaction.ReciverAccountNumber == element.AccountNumber).ToList());
            }

            transactions.Sort((t1,t2) => t2.StartTransactionDate.CompareTo(t1.StartTransactionDate));

            ViewBag.Transactions = transactions;
            ViewBag.Header = "Transactions";
            return View("Transactions");
        }


        [HttpPost]
        [Route("/Transactions")]
        public ActionResult MakeTransaction(IFormCollection form)
        {
            double amount = double.Parse(form["Amount"]);
            Account senderAccount = accountData.Where(account => account.AccountName == form["SenderAccount"]).ToList()[0]; 
            SenderReciverType myselfType = SenderReciverType.Myself;
            SenderReciverType strangerType = SenderReciverType.Myself;
            string reciverAccountNumber = form["ReciverAccountNumber"];
            Account reciverAccount = accountData.Where(account => account.AccountName == form["ReciverAccount"]).ToList()[0]; 
            TransactionTypeEnum normalTransactionType = TransactionTypeEnum.Normal;
            Console.WriteLine(amount);
            Console.WriteLine(senderAccount.AccountNumber);
            Console.WriteLine(reciverAccount.AccountNumber);
            Console.WriteLine(reciverAccountNumber);
            if (reciverAccountNumber == "")
            {
                Console.WriteLine("Tom");
                bankingContext.Add(new Transaction(amount, senderAccount.AccountNumber, myselfType, reciverAccount.AccountNumber, myselfType, normalTransactionType));
                bankingContext.SaveChanges();
            }
            else if (reciverAccountNumber != "")
            {
                Console.WriteLine("Fuldt");
                bankingContext.Add(new Transaction(amount, senderAccount.AccountNumber, myselfType, reciverAccountNumber, strangerType, normalTransactionType));
                bankingContext.SaveChanges();
            }

            return RedirectToAction("Transactions");
        }










    }

    }
