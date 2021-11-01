using System;

namespace InvestmentPortfolioValue.FakeDAL
{
    public class Transaction : IBaseEntity
    {
        public int ID { get; set; }
        public DateTime TransactionDate { get; set; }
        public IInstrument Instrument { get; set; }
        public double Amount { get; set; }
        public bool IsSale { get; set; }
        public int Cuantity { get; set; }

        public int PortFolioId { get; set; }

        // In the selling transactions, we need the purchansing price of each instrument by the tme it was bought to be able of calculating profit or lost correctly
        public double InstrumentPurchasePrice { get; set;  }

        public Transaction( int id, IInstrument instrument, DateTime date, double amount, bool isSale, int cuantity, int portfolioId, double purchasingPrice = 0)
        {
            ID = id;
            Instrument = instrument;
            TransactionDate = date;
            Amount = amount;
            IsSale = isSale;
            Cuantity = cuantity;
            PortFolioId = portfolioId;
            if (isSale) { InstrumentPurchasePrice = purchasingPrice; }
            else { InstrumentPurchasePrice = amount / cuantity;  }

        }
        
    }
}