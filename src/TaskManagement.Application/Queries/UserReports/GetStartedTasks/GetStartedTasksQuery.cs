using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.UserReports.DTOs;
using TaskManagement.Application.Queries.UserReports.Shared;

namespace TaskManagement.Application.Queries.UserReports.GetStartedTasks
{
	 public class GetStartedTasksQuery:IRequest<QueryResult<List<StartedTaskInfo>>>
	 {
		  public Guid UserId { get; set; }

		  public GetStartedTasksQuery(Guid userId)
		  {
			   UserId = userId;
		  }

		  internal class GetStartedTasksQueryHandler : IRequestHandler<GetStartedTasksQuery, QueryResult<List<StartedTaskInfo>>>
		  {
			   private readonly IUserReportsQueryService _userReportsQueryService;

			   public GetStartedTasksQueryHandler(IUserReportsQueryService userReportsQueryService)
			   {
					_userReportsQueryService = userReportsQueryService;
			   }

			   public async Task<QueryResult<List<StartedTaskInfo>>> Handle(GetStartedTasksQuery request, CancellationToken cancellationToken)
			   {
					var data =await _userReportsQueryService.GetStartedTaskReports(request.UserId);
					if (data == null) 
					{
						 return QueryResult<List<StartedTaskInfo>>.Failure("در پیدا کردن اطلاعات کاربر مشکلی وجود دارد");
					}
					return QueryResult<List<StartedTaskInfo>>.Success(data);


			   }
		  }
	 }
}
