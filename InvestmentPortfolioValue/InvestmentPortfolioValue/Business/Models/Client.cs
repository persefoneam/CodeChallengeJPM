using InvestmentPortfolioValue.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentPortfolioValue.Business.Models
{
    internal class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }
        // I'm asuming that a client can have just one portfolio
        public IPortfolio Portfolio { get; set; }

        public Client(int id)
        {
            Name = "";
            LastName = "";
            ID = id;
        }

        // Overloading the constructor to map from client repository entity, In a normal situation I would have a mmapping library such as AutoMapper.
        public Client(InvestmentPortfolioValue.FakeDAL.Client databaseClient)
        {
            Name = databaseClient.Name;
            LastName = databaseClient.LastName;
            ID = databaseClient.ID;
            Address = databaseClient.Address;
        }

        public void GeneratePortfolio(IEnumerable<InvestmentPortfolioValue.FakeDAL.Transaction> transactions)
        {
            Portfolio = new Portfolio(transactions.ToList(), ID);
        }
    }
}