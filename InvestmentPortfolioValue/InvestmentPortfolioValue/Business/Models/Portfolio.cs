using InvestmentPortfolioValue.Business.Interfaces;
using InvestmentPortfolioValue.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentPortfolioValue.Business.Models
{
    class Portfolio : IPortfolio
    {
        public IList<ITransaction> TransactionHistory { get; set; }
        public int ID { get; set; }

        public double BalanceUSD { get; set; }

        public double BalanceEUR { get; set; }

        public double BalanceInstrumentsUSD { get; set; }

        public double BalanceInstrumentsEUR { get; set; }

        public IList<CurrentHandlingInstrument> CurrentInvestmentsUSD { get; set; }
        public IList<CurrentHandlingInstrument> CurrentInvestmentsEUR { get; set; }

  
        public Portfolio(int id)
        {
            BalanceEUR = 0;
            BalanceUSD = 0;
            ID = id; 
        }


        public Portfolio(IEnumerable<InvestmentPortfolioValue.FakeDAL.Transaction> transactions, int id)
        {
            TransactionHistory = new List<ITransaction>();
            BalanceEUR = 0;
            BalanceUSD = 0;
            ID = id;

            // Mapping list of transactions history for this portfolio
            transactions.ToList().ForEach(t =>
               TransactionHistory.Add(new Transaction(t))
            );

            CalculateValueUSD();
            CalculateValueEUR();
            CalculateProfitLostUSD();
            CalculateProfitLostEUR();

        }

        // Im not converting from one currency to another, I'm assuming that a particular stock or bond can be just operated in the same currency
        public void CalculateValueUSD()
        {
            double balanceInstruments = 0;
            double balanceMoney = 0;

            // I'm asumming that the stock current price don't change in a milisecond. 

            //Grouping transactions by instrument and transaction type
            var r = TransactionHistory
                .Where(t => t.Instrument.Currency == Currency.USD)
                .GroupBy(t=> new { t.Instrument, t.IsSale })
                .Select(group => new { cuantity =  group.Sum(item => item.Cuantity), instrument = group.First().Instrument, isSold = group.First().IsSale, amount = group.First().Amount })
                .ToList();

            // Calculating the total value in USD in stocks and bonds
            balanceInstruments = r.Sum(x =>
            {
                double value = x.cuantity * x.instrument.GetCurrentPrice();
                if (x.isSold) value *= -1;
                return value; 

            });

            // Calculating the total value in USD in the account
            balanceMoney = r.Sum(x =>
            {
                if (x.isSold) return x.amount;
                else return x.amount * -1;
            });

            BalanceUSD = balanceMoney;

            BalanceInstrumentsUSD = balanceInstruments; 

        }

        // Im not converting from one currency to another, I'm assuming that a particular stock or bond can be just operated in the same currency
        public void CalculateValueEUR()
        {
            double balanceInstruments = 0;
            double balanceMoney = 0;

            // I'm asumming that the stock current price don't change in a milisecond. 

            //Grouping transactions by instrument and transaction type
            var r = TransactionHistory
                .Where(t => t.Instrument.Currency == Currency.EUR)
                .GroupBy(t => new { t.Instrument.Code, t.IsSale })
                .Select(group => new { cuantity = group.Sum(item => item.Cuantity), instrument = group.First().Instrument, isSold = group.First().IsSale, amount = group.First().Amount })
                .ToList();

            // Calculating the total value in USD in stocks and bonds
            balanceInstruments = r.Sum(x =>
            {
                double value = x.cuantity * x.instrument.GetCurrentPrice();
                if (x.isSold) value *= -1;
                return value;

            });

            // Calculating the total value in USD in the account
            balanceMoney = r.Sum(x =>
            {
                if (x.isSold) return x.amount;
                else return x.amount * -1;
            });

            BalanceEUR = balanceMoney;
            BalanceInstrumentsEUR = balanceInstruments;


        }

        // Calculating the total profit or lost on every instrument invested. Using transactions history because the same instrument can have different purchase prices if it was purchased in more than 1 time
        // Assuming that sold transactions has the purchase price, without it there's no way to know which instrument was sold (at which purchase price) and that would affect the numbers
        public void CalculateProfitLostUSD()
        {
            //Grouping transactions and calculating profit
            var r = TransactionHistory
                .Where(t => t.Instrument.Currency == Currency.USD)
                .GroupBy(t => new { t.Instrument.Code })
                .Select(group => new CurrentHandlingInstrument { 
                    ProfitOrLost = group.Sum(item => {
                        if (!item.IsSale) return item.Cuantity * (item.Instrument.GetCurrentPrice() - (item.Amount/ item.Cuantity));
                        else return -1 * (item.Cuantity * (item.Instrument.GetCurrentPrice() - item.InstrumentPurchasePrice)); //this is needed to remove the sold intruments from the list and not affect the total 
                    }),
                    Code = group.First().Instrument.Code,
                    Cuantity = group.Sum(item => {
                        if (!item.IsSale) return item.Cuantity;
                        else return -1 * item.Cuantity; }),
                    Currency = Currency.USD
                })
                .ToList();

            CurrentInvestmentsUSD = r; 
         
        }


        // Calculating the total profit or lost on every instrument invested. Using transactions history because the same instrument can have different purchase prices if it was purchased in more than 1 time
        // Assuming that sold transactions has the purchase price, without it there's no way to know which instrument was sold (at which purchase price) and that would affect the numbers
        public void CalculateProfitLostEUR()
        {
            //Grouping transactions and calculating profit
            var r = TransactionHistory
                .Where(t => t.Instrument.Currency == Currency.EUR)
                .GroupBy(t => new { t.Instrument.Code })
                .Select(group => new CurrentHandlingInstrument
                {
                    ProfitOrLost = group.Sum(item => {
                        double result = 0;
                        if (!item.IsSale) result =  item.Cuantity * (item.Instrument.GetCurrentPrice() - (item.Amount/ item.Cuantity));
                        else result = -1 * (item.Cuantity * (item.Instrument.GetCurrentPrice() - item.InstrumentPurchasePrice)); //this is needed to remove the sold intruments from the list and not affect the total 
                        return result;
                    }),
                    Code = group.First().Instrument.Code,
                    Cuantity = group.Sum(item => {
                        if (!item.IsSale) return item.Cuantity;
                        else return -1 * item.Cuantity;
                    }),
                    Currency = Currency.EUR
                })
                .ToList();

            CurrentInvestmentsEUR = r;
        }

        // Im just regenerating everything for timing issues on my work, but this performance can be enhanced by using snapshoots on this method
        public void UpdatePortfolio()
        {
            CalculateValueUSD();
            CalculateValueEUR();
            CalculateProfitLostUSD();
            CalculateProfitLostEUR();
        }


    }
}
