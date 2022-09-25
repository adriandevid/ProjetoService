using ProjetoService.Application.Responses.ApiResponse;

namespace ProjetoService.Application.Interfaces
{
    public interface IProjetoQueries
    {
        Task<ApiResponse> GetAll();
    }
}
