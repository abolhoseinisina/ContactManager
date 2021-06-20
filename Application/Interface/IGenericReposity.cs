using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<ICollection<TEntity>> List();
        public Task<TEntity> Get(object id);
        public Task Insert(TEntity entity);
        public Task Delete(object id);
        public Task Update(TEntity entityToUpdate);
    }
}
