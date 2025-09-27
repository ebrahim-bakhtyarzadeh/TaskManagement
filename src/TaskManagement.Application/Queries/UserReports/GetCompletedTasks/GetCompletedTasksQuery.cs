using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.UserReports.DTOs;
using TaskManagement.Application.Queries.UserReports.Shared;

namespace TaskManagement.Application.Queries.UserReports.GetCompletedTasks
{
 public   class GetCompletedTasksQuery	   :IRequest<QueryResult<List<CompletedTaskInfo>>>
    {
	   private Guid UserId { get; set; }
		public GetCompletedTasksQuery(Guid userId)
		{
			  UserId = userId;
		}




		  internal class GetCompletedTasksQueryHandler : IRequestHandler<GetCompletedTasksQuery,QueryResult< List<CompletedTaskInfo>>>
		  {
			   private readonly IUserReportsQueryService _queryService;

			   public GetCompletedTasksQueryHandler(IUserReportsQueryService queryService)
			   {
					_queryService = queryService;
			   }

			   public async Task<QueryResult<List<CompletedTaskInfo>>> Handle(GetCompletedTasksQuery request, CancellationToken cancellationToken)
			   {
					var info =await _queryService.GetCompletedTasksReport(request.UserId);
					if (info == null)
					{
						 return QueryResult<List<CompletedTaskInfo>>.Failure("در پیدا کردن اطلاعات کاربر مشکلی وجود دارد");
					}
					return QueryResult<List<CompletedTaskInfo>>.Success(info);
			   }
		  }
	 }
}
