using InvestmentPortfolioValue.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.Business.Interfaces
{
    public interface ITransaction
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public Instrument Instrument { get; set; }
        public double Amount { get; set; }
        public bool IsSale { get; set; }
        public int Cuantity { get; set; }
        public double InstrumentPurchasePrice { get; set; }
    }
}
