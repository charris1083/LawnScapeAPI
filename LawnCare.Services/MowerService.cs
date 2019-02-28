using LawnCare.Data;
using LawnCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnCare.Services
{
    public class MowerService
    {
        private readonly Guid _userId;

        public MowerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMower(MowerCreate model)
        {
            var entity =
                new Mower()
                {
                    LandscapeId = _userId,
                    MowerName = model.MowerName,
                    MowerCity = model.MowerCity,
                    MowerRate = model.MowerRate,
                    MowerService = model.MowerService
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Mowers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MowerListItem> GetMowers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Mowers
                    .Where(e => e.LandscapeId == _userId)
                    .Select(
                        e =>
                        new MowerListItem
                        {
                            MowerId = e.MowerId,
                            MowerName = e.MowerName,
                            MowerCity = e.MowerCity,
                            MowerRate = e.MowerRate,
                            MowerService = e.MowerService
                        });
                return query.ToArray();
            }
        }
        public MowerDetail GetMowerById(int mowerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Mowers
                    .Single(e => e.MowerId == mowerId && e.LandscapeId == _userId);
                return
                    new MowerDetail
                    {
                        MowerId = entity.MowerId,
                        MowerName = entity.MowerName,
                        MowerCity = entity.MowerCity,
                        MowerRate = entity.MowerRate,
                        MowerService = entity.MowerService
                    };
            }
        }
        public bool UpdateMower(MowerEdit model)
        {
             using (var ctx =  new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Mowers
                    .Single(e => e.MowerId == model.MowerId && e.LandscapeId == _userId);
                entity.MowerId = model.MowerId;
                entity.MowerName = model.MowerName;
                entity.MowerCity = model.MowerCity;
                entity.MowerService = model.MowerService;
                entity.MowerRate = model.MowerRate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteMower(int mowerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Mowers
                    .Single(e => e.MowerId == mowerId && e.LandscapeId == _userId);
                ctx.Mowers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
