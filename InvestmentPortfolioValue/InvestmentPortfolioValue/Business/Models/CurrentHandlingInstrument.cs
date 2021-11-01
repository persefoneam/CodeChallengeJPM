using InvestmentPortfolioValue.Business.Interfaces;
using InvestmentPortfolioValue.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioValue.Business.Models
{
    public class CurrentHandlingInstrument : IInstrument
    {
        public string Code { get; set; }

        public int Cuantity { get; set; }

        public Currency Currency { get; set; }

        public double ProfitOrLost { get; set; }

        public CurrentHandlingInstrument()
        {

        }

    }
}
