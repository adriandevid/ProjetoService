using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoService.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        Task<List<TEntity>> GetAll();
        TEntity GetById(long id);
    }
}
