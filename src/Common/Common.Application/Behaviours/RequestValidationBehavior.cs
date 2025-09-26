using Common.Application.Exceptions;
using FluentValidation;
using MediatR;
using System.Text;

public class RequestValidationBehavior<TRequest, TResponse>
	: IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	 private readonly IEnumerable<IValidator<TRequest>> validators;

	 public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		 => this.validators = validators;

	 public async Task<TResponse> Handle(
		 TRequest request,
		 RequestHandlerDelegate<TResponse> next,
		 CancellationToken cancellationToken)
	 {
		  var context = new ValidationContext<TRequest>(request);

		  var errors = validators
			  .Select(v => v.Validate(context))
			  .SelectMany(result => result.Errors)
			  .Where(f => f != null)
			  .ToList();

		  if (errors.Any())
		  {
			   var errorBuilder = new StringBuilder();

			   foreach (var error in errors)
			   {
					errorBuilder.AppendLine(error.ErrorMessage);
			   }

			   throw new InvalidCommandException(errorBuilder.ToString(), null);
		  }
		  var response = await next();
		  return response;
	 }
}