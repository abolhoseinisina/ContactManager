using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public ICollection<TEntity> List();
        public TEntity Get(object id);
        public void Insert(TEntity entity);
        public void Delete(object id);
        public void Update(TEntity entityToUpdate);
    }
}
