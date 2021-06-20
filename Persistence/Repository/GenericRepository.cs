using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual async Task<ICollection<TEntity>> List()
        {
            //return dbSet.FromSqlRaw("GetContacts").ToList();
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Get(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task Insert(TEntity entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
            }
            catch
            {
                throw new InvalidOperationException("Error adding entity to DB.");
            }
        }

        public virtual async Task Delete(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete == null) throw new InvalidOperationException("Could not find an entity with this id: " + id);
            try
            {
                dbSet.Remove(entityToDelete);
            }
            catch
            {
                throw new InvalidOperationException("Error deleting entity from DB.");
            }
        }

        public virtual async Task Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }
            catch
            {
                throw new InvalidOperationException("Error updating entity in the DB.");
            }
            await Task.CompletedTask;
        }
    }
}
