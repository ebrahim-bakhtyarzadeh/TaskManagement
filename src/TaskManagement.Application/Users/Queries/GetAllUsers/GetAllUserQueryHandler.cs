using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Users.Queries.DTOs;
using TaskManagement.Application.Users.Queries.Shared;

namespace TaskManagement.Application.Users.Queries.GetAllUsers
{
    internal class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, QueryResult<List<UserDto>>>
    {
        private readonly IUserService _userService;
        public GetAllUserQueryHandler(IUserService userService)
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
