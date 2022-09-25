using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ProjetoService.Application.Responses.ApiResponse;

namespace ProjetoService.Application.Pipe
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : ApiResponse
    {
        public readonly IEnumerable<IValidator<TRequest>> _validators;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var validations = _validators.ToList();

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                return Errors(failures);
            }

            return await next();
        }

        private static TResponse Errors(IEnumerable<ValidationFailure> failures)
            => new ApiResponse { ValidationResult = new ValidationResult(failures) } as TResponse;
    }
}
