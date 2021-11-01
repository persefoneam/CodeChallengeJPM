using InvestmentPortfolioValue.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.Business.Models
{
    class Transaction : ITransaction
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public Instrument Instrument { get; set; }
        public double Amount { get; set; }
        public bool IsSale { get; set; }
        public int Cuantity { get; set; }
        public double InstrumentPurchasePrice { get; set; }

        public Transaction(int id, Instrument instrument, DateTime date, double amount, bool isSale, int cuantity)
        {
            ID = id;
            Instrument = instrument;
            TransactionDate = date;
            Amount = amount;
            IsSale = isSale;
            Cuantity = cuantity;
        }

        // Overloading the constructor to map from transction repository entity, In a normal situation I would have a mmapping library such as AutoMapper.
        public Transaction(InvestmentPortfolioValue.FakeDAL.Transaction transaction)
        {
            ID = transaction.ID;
            if (transaction.Instrument.GetType().Equals(typeof(InvestmentPortfolioValue.FakeDAL.Bond)))
            {
                Instrument = new Bond(transaction.Instrument);
            }
            else
            {
                Instrument = new Stock(transaction.Instrument);
            }
            TransactionDate = transaction.TransactionDate;
            Amount = transaction.Amount;
            IsSale = transaction.IsSale;
            Cuantity = transaction.Cuantity;
            InstrumentPurchasePrice = transaction.InstrumentPurchasePrice;
        }
    }
}
