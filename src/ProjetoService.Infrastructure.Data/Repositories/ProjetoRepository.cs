using ProjetoService.Domain.Entities;
using ProjetoService.Domain.Interfaces;
using ProjetoService.Infrastructure.Data.Context;
using ProjetoService.Infrastructure.Data.Repositories.Base;

namespace ProjetoService.Infrastructure.Data.Repositories
{
    public class ProjetoRepository: BaseRepository<Projeto>, IProjetoRepository
    {
        private readonly ApplicationContext _context;

        public ProjetoRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    }
}
