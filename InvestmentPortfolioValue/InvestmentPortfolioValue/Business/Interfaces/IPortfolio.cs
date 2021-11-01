using InvestmentPortfolioValue.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace InvestmentPortfolioValue.Business.Interfaces
{
    public interface IPortfolio
    {
        public IList<ITransaction> TransactionHistory { get; set; }
        public int ID { get; set; }
        public IList<CurrentHandlingInstrument> CurrentInvestmentsUSD { get; set; }
        public IList<CurrentHandlingInstrument> CurrentInvestmentsEUR { get; set; }

        public double BalanceInstrumentsUSD { get; set; }

        public double BalanceInstrumentsEUR { get; set; }

        public double BalanceUSD { get; set; }

        public double BalanceEUR { get; set; }

        public void CalculateValueUSD();

        public void CalculateValueEUR();

        public void CalculateProfitLostUSD();

        public void CalculateProfitLostEUR();

        public void UpdatePortfolio();


    }
}
