using System.Collections.Generic;

namespace InvestmentPortfolioValue.FakeDAL
{
    internal interface ITransactionRepository
    {
        Transaction GetByID(int id);
        IEnumerable<Transaction> GetAll();


    }
}