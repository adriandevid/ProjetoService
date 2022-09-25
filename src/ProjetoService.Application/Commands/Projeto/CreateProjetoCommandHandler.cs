using MediatR;
using ProjetoService.Application.Requests.Projeto;
using ProjetoService.Application.Responses.ApiResponse;

namespace ProjetoService.Application.Commands.Projeto
{
    public class CreateProjetoCommandHandler : CommandHandler, IRequestHandler<CreateProjetoRequest, ApiResponse>
    {
        public Task<ApiResponse> Handle(CreateProjetoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
