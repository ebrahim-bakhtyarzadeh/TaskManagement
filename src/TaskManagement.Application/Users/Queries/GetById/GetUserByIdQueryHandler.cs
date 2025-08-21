using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Users.Queries.DTOs;
using TaskManagement.Application.Users.Queries.Shared;

namespace TaskManagement.Application.Users.Queries.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, QueryResult<UserDto>>
    {
        private readonly IUserService _userService;


        public async Task<QueryResult<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserById(request.userId, cancellationToken);
            if (user == null)
            {
                return QueryResult<UserDto>.Failure("کاربر مورد نظر یافت نشد");
            }

            return QueryResult<UserDto>.Success(user, "کاربر مورد نظر یافت شد");


        }
    }
}
