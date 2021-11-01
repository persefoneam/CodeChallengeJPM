using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.FakeDAL
{
    public class Client : IBaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ID  { get; set; }
        public string Address { get; set; }
    }
}
