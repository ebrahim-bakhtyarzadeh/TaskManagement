using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Common.Application
{
	 public static class ApplicationConfiguration
	 {


		  public static IServiceCollection AddCommonApplication(
	 this IServiceCollection services,
	 IConfiguration configuration,
	 Assembly assembly)
	 => services
		 .Configure<ApplicationSettings>(
			 configuration.GetSection(nameof(ApplicationSettings)), options => options.BindNonPublicProperties = true)


		 .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
		 .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
	 }
}
