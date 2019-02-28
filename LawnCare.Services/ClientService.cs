using LawnCare.Data;
using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Services
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    CustomerId = _userId,
                    ClientName = model.ClientName,
                    ClientCity = model.ClientCity,
                    ClientNeeds = model.ClientNeeds,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Clients
                    .Where(e => e.CustomerId == _userId)
                    .Select(
                        e =>
                        
                            new ClientListItem
                            {
                                ClientId = e.ClientId,
                                ClientName = e.ClientName,
                                ClientCity = e.ClientCity,
                                ClientNeeds = e.ClientNeeds
                            }
                        );
                return query.ToArray();
            }
        }
        public ClientDetail GetClientById(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientId == clientId && e.CustomerId == _userId);
                return
                    new ClientDetail
                    {
                        ClientId = entity.ClientId,
                        ClientName = entity.ClientName,
                        ClientCity = entity.ClientCity,
                        ClientNeeds = entity.ClientNeeds
                    };
            }
        }
        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx =  new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientId == model.ClientId && e.CustomerId == _userId);
                entity.ClientId = model.ClientId;
                entity.ClientName = model.ClientName;
                entity.ClientCity = model.ClientCity;
                entity.ClientNeeds = model.ClientNeeds;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientId == clientId && e.CustomerId == _userId);
                ctx.Clients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
