using InvestmentPortfolioValue.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.Business.Models
{
    class Bond : Instrument
    {
        public override string Code { get; set; }
        public override Currency Currency { get; set; }

        public Bond(string code, Currency currency) : base(code,currency)
        {

        }

        public Bond(InvestmentPortfolioValue.FakeDAL.IInstrument bond) : base(bond.Code, bond.Currency)
        {
            // Any other different property should be instanciated here
        }
    }
}
