using FluentValidation;
using ProjetoService.Application.Requests.Projeto;

namespace ProjetoService.Application.Validations.Projeto
{
    public class CreateProjetoValidation : AbstractValidator<CreateProjetoRequest>
    {
        public CreateProjetoValidation()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(MessageResources.MessageResources.Descricao);
        }
    }
}
