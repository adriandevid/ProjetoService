using ProjetoService.Application.Responses.ApiResponse;
using ProjetoService.Domain.Interfaces;
using System.Data.Common;

namespace ProjetoService.Application.Commands
{
    public class CommandHandler : ResponseHandler
    {
        protected async Task<ApiResponse> PersistDataAsync(IUnitOfWork uow)
        {
            try
            {
                if (!await uow.Commit()) AddError("Houve um erro ao persistir os dados");

            }
            catch (DbException ex)
            {
                AddError(ex.Message);
            }

            return Response;
        }
    }
}
