using InvestmentPortfolioValue.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using InvestmentPortfolioValue.Communication;
using System.Threading.Tasks;
using InvestmentPortfolioValue.Commons.Enums;

namespace InvestmentPortfolioValue.Business.Models
{
    public abstract class Instrument : IInstrument
    {
        public abstract string Code { get; set; }
        
        // I'm assuming that an instrument can be operated in just one currency. E.G I cannot buy U.S stoock in EUROS. 
        public abstract Currency Currency { get; set; }

        public Instrument(string code, Currency currency)
        {
            Code = code;
            Currency = currency;

        }
      
        public virtual double GetCurrentPrice()
        {
            try
            {
                var task = Task.Run<double>(async () => await ExternalService.GetCurrentPrice(Code));
                double price = task.Result;
                return price;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
