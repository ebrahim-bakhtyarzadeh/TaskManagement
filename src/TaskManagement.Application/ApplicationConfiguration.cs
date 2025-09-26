using Common.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Commands;
using TaskManagement.Application.Users.Queries.GetById;
using TaskManagement.Domain.TasksAgg.Factories;
using TaskManagement.Domain.UsersAgg.Services;

namespace TaskManagement.Application
{
	 public static class ApplicationConfiguration
	 {
		  public static void RegisterApplicationDependencies(this IServiceCollection services)
		  {
			   services.AddTransient<IUserDomainService, UserDomainService>();
			   services.AddTransient<ITaskFactory, Domain.TasksAgg.Factories.TaskFactory>();

			   ApplicationCommonConfiguration.Init(services);
			   services.AddMediatR(cfg =>
			   cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQuery).Assembly));
		  }
	 }
}
