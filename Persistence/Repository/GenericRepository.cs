using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ContactContext context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(ContactContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual ICollection<TEntity> List()
        {
            //return dbSet.FromSqlRaw("GetContacts").ToList();
            return dbSet.ToList();
        }

        public virtual TEntity Get(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
