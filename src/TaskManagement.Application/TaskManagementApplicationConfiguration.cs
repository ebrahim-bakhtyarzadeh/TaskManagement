using Common.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TaskManagement.Application
{
	 public static class TaskManagementApplicationConfiguration
	 {
		  private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

		  public static IServiceCollection AddOrderManagementApplication(
			  this IServiceCollection services,
			  IConfiguration configuration)
			  => services
				  .AddCommonApplication(configuration, Assembly);
	 }
}
