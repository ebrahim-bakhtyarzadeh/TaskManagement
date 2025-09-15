namespace Common.Application.Exceptions
{
	 public class ValidationException(string message = "خطای اعتبار سنجی") : Exception(message);
	 public class NotFoundException(string message = "داده ای یافت نشد") : Exception(message);

	 public class ServerErrorException(string message = "خطایی هنگام انجام عملیات رخ داد") : Exception(message);
}
