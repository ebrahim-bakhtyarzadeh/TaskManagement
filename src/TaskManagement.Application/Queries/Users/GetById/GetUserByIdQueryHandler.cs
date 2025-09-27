using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Queries.Users.DTOs;
using TaskManagement.Application.Queries.Users.Shared;

namespace TaskManagement.Application.Queries.Users.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, QueryResult<UserDto>>
    {
        private readonly IUserQueryService _userService;

        public GetUserByIdQueryHandler(IUserQueryService userService)
        {
            _userService = userService;
        }
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
