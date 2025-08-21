using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Queries.DTOs;
using TaskManagement.Application.Users.Queries.Shared;

namespace TaskManagement.Application.Users.Queries.GetActiveUsers
{
    public record GetActiveUsersQuery:IRequest<QueryResult<List<UserDto>>>;

    public class GetActiveUserQueryHandler : IRequestHandler<GetActiveUsersQuery, QueryResult<List<UserDto>>>
    {
        private readonly IUserService _userService;

        public GetActiveUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<QueryResult<List<UserDto>>> Handle(GetActiveUsersQuery request, CancellationToken cancellationToken)
        {
            var activeUsers =await _userService.GetActiveUsers(cancellationToken);
            if (activeUsers == null)
            {
                return QueryResult<List<UserDto>>.Failure("کاربری وجود ندارد");

            }
            return QueryResult<List<UserDto>>.Success(activeUsers, "لیست کاربر ها :");
        }
    }
}
