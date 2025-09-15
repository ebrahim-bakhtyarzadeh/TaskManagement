using FluentValidation.Results;

namespace Common.Application.Exceptions
{
	 public class ModelValidationException
	 : Exception
	 {
		  public ModelValidationException()
			  : base("یک یا چند خطای اعتبار سنجی رخ داده است .")
			  => Errors = new Dictionary<string, string[]>();

		  public ModelValidationException(IEnumerable<ValidationFailure> errors)
			  : this()
		  {
			   var failureGroups = errors
				   .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

			   foreach (var failureGroup in failureGroups)
			   {
					var propertyName = failureGroup.Key;
					var propertyFailures = failureGroup.ToArray();

					Errors.Add(propertyName, propertyFailures);
			   }
		  }

		  public IDictionary<string, string[]> Errors { get; }
	 }
}
