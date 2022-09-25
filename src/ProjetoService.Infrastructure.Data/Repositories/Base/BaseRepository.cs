using Microsoft.EntityFrameworkCore;
using ProjetoService.Domain.Interfaces;
using ProjetoService.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoService.Infrastructure.Data.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
