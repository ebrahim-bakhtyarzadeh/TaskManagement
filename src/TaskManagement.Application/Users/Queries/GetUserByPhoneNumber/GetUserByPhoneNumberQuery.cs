using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Queries.DTOs;
using TaskManagement.Application.Users.Queries.Shared;

namespace TaskManagement.Application.Users.Queries.GetUserByPhoneNumber
{
    public record GetUserByPhoneNumberQuery(string phoneNumber) :IRequest<QueryResult<UserDto>>;
    
    public class GetUserByPhoneNumberQueryHandler : IRequestHandler<GetUserByPhoneNumberQuery, QueryResult<UserDto>>
    {
        private readonly IUserQueryService _userQueryService;

        public GetUserByPhoneNumberQueryHandler(IUserQueryService userQueryService)
        {
            _userQueryService = userQueryService;
        }

        public async Task<QueryResult<UserDto>> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
        {
            var user =await _userQueryService.GetUserByPhoneNumber(request.phoneNumber, cancellationToken);
            if (user == null)
            {
                return QueryResult<UserDto>.Failure("کاربر مورد نظر یافت نشد");
            }
            return QueryResult<UserDto>.Success(user);
        }
    }
}
