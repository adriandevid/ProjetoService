using FluentValidation;
using ProjetoService.Application.Requests.Projeto;

namespace ProjetoService.Application.Validations.Projeto
{
    public class UpdateProjetoValidation : AbstractValidator<UpdateProjetoRequest>
    {
        public UpdateProjetoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(MessageResources.MessageResources.Id);
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(MessageResources.MessageResources.Descricao);
        }
    }
}
