using MediatR;
using ProjetoService.Application.Responses.ApiResponse;

namespace ProjetoService.Application.Requests.Projeto
{
    public class DeleteProjetoRequest : IRequest<ApiResponse>
    {
        public long  Id { get; set; }
    }
}
