using InvestmentPortfolioValue.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.Business.Models
{
    class Stock: Instrument
    {
        public override string Code { get; set; }
        public override Currency Currency { get; set; }

        public Stock(InvestmentPortfolioValue.FakeDAL.IInstrument stock) : base(stock.Code, stock.Currency)
        {
            // Any other different property should be instanciated here
        }
    }
}
