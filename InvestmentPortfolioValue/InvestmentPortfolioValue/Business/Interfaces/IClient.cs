using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.Business.Interfaces
{
    public interface IClient
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }
        // I'm asuming that a client can have just one portfolio
        public IPortfolio Portfolio { get; set; }
    }
}
