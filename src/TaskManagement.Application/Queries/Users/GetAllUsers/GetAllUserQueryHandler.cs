using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Queries.Users.DTOs;
using TaskManagement.Application.Queries.Users.Shared;

namespace TaskManagement.Application.Queries.Users.GetAllUsers
{
    internal class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, QueryResult<List<UserDto>>>
    {
        private readonly IUserQueryService _userService;
        public GetAllUserQueryHandler(IUserQueryService userService)
        {
            _userService = userService;
        }

        public async Task<QueryResult<List<UserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _userService.GetAllUsers(cancellationToken);
            if (allUsers == null)
            {
                return QueryResult<List<UserDto>>.Failure("کاربری وجود ندارد");

            }
            return QueryResult<List<UserDto>>.Success(allUsers, "لیست کاربر ها :");


        }
    }
}
