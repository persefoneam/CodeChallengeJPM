using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.FakeDAL.Repos
{
    interface IClientRepository
    {
        Client GetByID(int id);
        IEnumerable<Client> GetAll();

    }
}
