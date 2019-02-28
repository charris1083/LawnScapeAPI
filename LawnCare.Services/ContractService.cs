using LawnCare.Data;
using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = LawnCare.Data.Contract;

namespace LawnCare.Services
{
    public class ContractService
    {
        private readonly Guid _userId;

        public ContractService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateContract(ContractCreate model)
        {
            var entity =
                new Contract()
                {
                    OwnerId = _userId,
                    ClientId = model.ClientId,
                    MowerId = model.MowerId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Contracts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
            public IEnumerable<ContractListItem> GetContracts()
            {
                using(var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .Contracts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                            new ContractListItem
                            {
                                ContractId = e.ContractId,
                                ClientName = e.Client.ClientName,
                                MowerName = e.Mower.MowerName,
                                ClientCity = e.Client.ClientCity,
                                MowerService = e.Mower.MowerService,
                                MowerRate = e.Mower.MowerRate
                            });
                    return query.ToArray();
                }
            }
        public ContractDetail GetContractById(int contractId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Contracts
                    .Single(e => e.ContractId == contractId && e.OwnerId == _userId);
                return
                    new ContractDetail()
                    {
                        ClientId = entity.ClientId,
                        MowerId= entity.MowerId,
                        ClientCity = entity.Client.ClientCity,
                        MowerService = entity.Mower.MowerService
                    };
            }
        }

        public bool UpdateContract(ContractEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Contracts
                    .Single(e => e.ContractId == model.ContractId && e.OwnerId == _userId);
                entity.Client.ClientName = model.ClientName;
                entity.Mower.MowerName = model.MowerName;
                entity.Client.ClientCity = model.ClientCity;
                entity.Mower.MowerService = model.MowerService;
                entity.Mower.MowerRate = model.MowerRate;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteContract(int contractId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Contracts
                    .Single(e => e.ClientId == contractId && e.OwnerId == _userId);
                ctx.Contracts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
