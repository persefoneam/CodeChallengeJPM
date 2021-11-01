using InvestmentPortfolioValue.FakeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Business =  InvestmentPortfolioValue.Business;
using Repos = InvestmentPortfolioValue.FakeDAL;

namespace InvestmentPortfolioValue
{
    // Main assumptions, comments: 

     // 1 - I'm assuming that an instrument can be operated in just one currency. E.G I cannot buy U.S stoock in EUROS. 
     // 2 - I'm assuming that A Client (Person) can have just one portfolio
     // 3 - I'm asuming that the original transactions systems blocks short positions (Sell an instroment to purchase it later cheaper), anyway, Im also asumming
     // that the system allows to purchase the same instrument in different transactions, so I'm considering this and sell transactions in the profit/loss calculation
     // 4- I'm just taking into account transactions to buy or sell instruments, I'm not taking into account deposits or extractions, that's why balances can be negative
     // 5- Im using a repository pattern on a fake DAL layer. 
    class Program
    {
        static void Main(string[] args)
        {
            // Generating the repositories to interact with the fake database on DAL layer. 

            // This would be different using a dependecy injection framework (or the dependency injection embeded on net core) in that situation..
            // I would add the instances of repositories in a dependencies container
            TransactionRepository repoTransactions = new TransactionRepository();
            ClientRepository repoClients = new ClientRepository();

            //Asking the user to introduce the client ID to value portfolio. 
            Console.WriteLine("Please introduce the client ID (fake clients Id  = 1 or 2)");
            string clientIdInput = Console.ReadLine();


            bool parsed =  Int32.TryParse(clientIdInput, out int clientId); 
            //validating the client ID as an integer
            if (!parsed)
            {
                Console.WriteLine("Invalid client ID");
                return;
            }

            //Finding Client in the repository. 
            Repos.Client clientFromRepo = repoClients.GetByID(clientId);

            if(clientFromRepo == null)
            {
                Console.WriteLine("Client Not Found");
                return;
            }

            // Creating actual client 
            Business.Models.Client c1 = new Business.Models.Client(clientFromRepo);

            //Getting client's transactions history
            List<Repos.Transaction> clientTransactions = repoTransactions.GetByClientId(c1.ID).ToList();

            if (clientTransactions.Count == 0)
            {
                Console.WriteLine("Client dont have any transactions, we cannot value the associated portfolio");
            }

            //Generating Client Portfolio 
            c1.GeneratePortfolio(clientTransactions);


            Console.WriteLine("Value in USD (money): " + c1.Portfolio.BalanceUSD);
            Console.WriteLine("Value in EUR (Money): " + c1.Portfolio.BalanceEUR);

            Console.WriteLine("Value in USD (instruments): " + c1.Portfolio.BalanceInstrumentsUSD);
            Console.WriteLine("Value in EUR (instruments): " + c1.Portfolio.BalanceInstrumentsEUR);

            c1.Portfolio.CalculateProfitLostEUR();
            c1.Portfolio.CalculateProfitLostUSD();
            //showing the transaction history
            Console.WriteLine("---------------------Current Investments profit / lost  USD--------------------------------");
            Console.WriteLine("CODE / Cuantity / Profit - Lost");
            c1.Portfolio.CurrentInvestmentsUSD.ToList().ForEach(t =>
            {
                Console.WriteLine(t.Code + " / " + t.Cuantity + " / " + t.ProfitOrLost);
            });

            Console.WriteLine("---------------------Current Investments profit / lost  EUR--------------------------------");
            Console.WriteLine("CODE / Cuantity / Profit - Lost");
            c1.Portfolio.CurrentInvestmentsEUR.ToList().ForEach(t =>
            {
                Console.WriteLine(t.Code + " / " + t.Cuantity + " / " + t.ProfitOrLost);
            });

        }
    }
}
