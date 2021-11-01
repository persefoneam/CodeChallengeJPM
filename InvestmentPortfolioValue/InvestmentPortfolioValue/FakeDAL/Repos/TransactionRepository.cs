using InvestmentPortfolioValue.Commons.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentPortfolioValue.FakeDAL
{
    class TransactionRepository: ITransactionRepository
    {
        // A context to conect to the database or ORM should be declared here, in this case I'll just manuallu create a transaction list on the class constructo 

        private List<Transaction> TransactionHistory { get; set; }
    
        public TransactionRepository()
        {
            TransactionHistory = new List<Transaction>();

            // Creating 4 different instruments. 
            Bond b1 = new Bond { Code = "AY24", Currency= Currency.EUR };
            Bond b2 = new Bond { Code = "AY24D", Currency = Currency.USD };
            Bond b3 = new Bond { Code = "AY24C", Currency = Currency.USD };
            Stock s1 = new Stock { Code = "MELI", Currency = Currency.EUR };
            Stock s2 = new Stock { Code = "MSFT", Currency = Currency.USD };

            // Manually generating the list of transactions for portfolio Id 1 instead of connecting to the db or EF
            TransactionHistory.Add(new Transaction(1,b1,DateTime.Parse("2009/01/01"),10.5,false,50, 1));
            TransactionHistory.Add(new Transaction(2,b1, DateTime.Parse("2009/02/10"), 14, true, 10, 1, 0.21));
            TransactionHistory.Add(new Transaction(3,b1, DateTime.Parse("2010/01/01"), 2, true, 10, 1, 0.21));
            //TransactionHistory.Add(new Transaction(4,b2, DateTime.Parse("2010/01/02"), 55.2, false, 100, 1));
            //TransactionHistory.Add(new Transaction(5,b3, DateTime.Parse("2011/01/05"), 45.3, false, 53, 1));
            //TransactionHistory.Add(new Transaction(6,s1, DateTime.Parse("2011/01/20"), 10.5, false, 25, 1));
            //TransactionHistory.Add(new Transaction(7,s2, DateTime.Parse("2016/01/25"), 15.5, false, 55, 1));
            //TransactionHistory.Add(new Transaction(8,s1, DateTime.Parse("2017/01/01"), 200, true, 20, 1, 2.38));

            // Manually generating the list of transactions for portfolio Id 2 instead of connecting to the db or EF
            TransactionHistory.Add(new Transaction(10, b1, DateTime.Parse("2009/01/01"), 10.5, false, 50, 2));
            TransactionHistory.Add(new Transaction(11, b1, DateTime.Parse("2009/02/10"), 14, true, 10, 2, 0.21));
            TransactionHistory.Add(new Transaction(12, b1, DateTime.Parse("2010/01/01"), 2, true, 10, 2, 0.21));
            TransactionHistory.Add(new Transaction(13, b2, DateTime.Parse("2010/01/02"), 55.2, false, 100, 2));
            TransactionHistory.Add(new Transaction(14, b3, DateTime.Parse("2011/01/05"), 45.3, false, 53, 2));
            TransactionHistory.Add(new Transaction(15, s1, DateTime.Parse("2011/01/20"), 10.5, false, 25, 2));
            TransactionHistory.Add(new Transaction(16, s2, DateTime.Parse("2016/01/25"), 15.5, false, 55, 2));
     

        }

        public IEnumerable<Transaction> GetByClientId(int clientId)
        {
           // returning the lis generated, in not fake situation here we osuld query the database
            return TransactionHistory.Where(t => t.PortFolioId == clientId).ToList();

        }

        public IEnumerable<Transaction> GetAll()
        {
            // returning the lis generated, in not fake situation here we osuld query the database
            return TransactionHistory;

        }

        public Transaction GetByID(int transactionId)
        {
            return TransactionHistory.Where(x => x.ID == transactionId).FirstOrDefault(); 
        }

      
    }
}
