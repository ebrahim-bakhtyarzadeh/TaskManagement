using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Application
{
	 public static class ApplicationCommonConfiguration
	 {


		  public static void Init(IServiceCollection service)
		  {
			   service.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
		  }
	 }
}
