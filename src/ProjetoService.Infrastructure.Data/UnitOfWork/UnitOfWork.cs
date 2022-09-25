using ProjetoService.Domain.Interfaces;
using ProjetoService.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoService.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
