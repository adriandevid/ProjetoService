using MediatR;
using ProjetoService.Application.Responses.ApiResponse;

namespace ProjetoService.Application.Requests.Projeto
{
    public class CreateProjetoRequest : IRequest<ApiResponse>
    {
        public string Descricao { get; set; }
    }
}
