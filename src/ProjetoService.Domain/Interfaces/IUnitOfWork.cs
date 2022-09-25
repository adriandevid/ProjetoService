

namespace ProjetoService.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
