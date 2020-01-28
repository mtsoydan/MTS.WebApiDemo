using Microsoft.EntityFrameworkCore;
using MTS.WebApiDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.DataAcces
{
    public class EFRepositoryBase<Tentity, Tcontext> : IEntityRepository<Tentity>
          where Tentity : class, IEntity, new()
        where Tcontext : DbContext, new()

    {
        public void Add(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new Tcontext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

   

        public List<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
                if (filter == null)
                {
                    return context.Set<Tentity>().ToList();
                }
                else
                {
                    return context.Set<Tentity>().Where(filter).ToList();
                }
            }
        }

        

        public void Update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                var UptatedEntity = context.Entry(entity);
                UptatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
