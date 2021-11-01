using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioValue.Communication
{
    //this is a very simple mock of a communication layer with an external server, by now I'm just returning a number as a current price
    static class ExternalService
    {
        public static async Task<double> GetCurrentPrice(string code)
        {
            //here should happen the communication with the server, by now I'm just returning an object

            //should be something like await api.getprice()...
            await Task.Delay(0);
           
             // returning always the same number, I could return a random number but it would make the manual testing for this challenge complicated
            return 5;
        }
    }
}
