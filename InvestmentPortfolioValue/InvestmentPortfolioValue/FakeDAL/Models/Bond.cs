using InvestmentPortfolioValue.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.FakeDAL
{
    class Bond : IInstrument
    {
        public string Code { get; set; }
        public Currency Currency { get; set; }
    }
}
