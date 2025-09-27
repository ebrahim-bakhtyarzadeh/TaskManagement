using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.Tasks.Shared;
using TaskManagement.Application.Queries.UserReports.Shared;
using TaskManagement.Application.Queries.Users.Shared;
using TaskManagement.Domain.TasksAgg.Repository;
using TaskManagement.Domain.UsersAgg.Repository;
using TaskManagement.Infrastructure.EF.Persistent.Ef;
using TaskManagement.Infrastructure.EF.Persistent.Ef.TaskDataAccess;
using TaskManagement.Infrastructure.EF.Persistent.Ef.UserDataAccess;
using TaskManagement.Infrastructure.EF.Persistent.Ef.UserDataAccess.UserReports;


namespace TaskManagement.Infrastructure
{
	 public static class InfrastructureBootstrapper
	 {
		  public static void Init(this IServiceCollection services, string dbConnectionString)
		  {

			   services.AddDbContext<TaskManagementContext>(option =>
			   {
					option.UseSqlServer(dbConnectionString);
			   });

			   services.AddTransient<IUserRepository, UserRepository>();
			   services.AddTransient<ITaskRepository, TaskRepository>();
			   services.AddTransient<IUserQueryService, UserQueryService>();
			   services.AddTransient<ITaskQueryService, TaskQueryService>();
			   services.AddTransient<IUserReportsQueryService , UserReportsQueryService>();



		  }
	 }
}
