using InvestmentPortfolioValue.FakeDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentPortfolioValue.FakeDAL
{
    class ClientRepository : IClientRepository
    {
        private List<Client> Clients { get; set; }
        public ClientRepository()
        {
            Clients = new List<Client>();

            Clients.Add(new Client { ID = 1, Address = "Address 1", Name = "Jhon", LastName = "Smith" });
            Clients.Add(new Client { ID = 2, Address = "Address 2", Name = "Maria", LastName = "Perez" });

        }
       
        public IEnumerable<Client> GetAll()
        {
            // returning the lis generated, in not fake situation here we osuld query the database
            return Clients;

        }

        public Client GetByID(int clientId)
        {
            return Clients.Where(x => x.ID == clientId).FirstOrDefault();
        }

    }
}
