using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.Users.DTOs;
using TaskManagement.Application.Queries.Users.Shared;
using TaskManagement.Domain.UsersAgg.Repository;

namespace TaskManagement.Application.Queries.Users.GetUserTokenByJwtToken
{
	 public record GetUserTokenByJwtTokenQuery(Guid userId,string jwtToken)	:IRequest<UserTokenDto?>;
	 public class GetUserTokenByJwtTokenQueryHandler : IRequestHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
	 {
		  private readonly IUserQueryService _userQueryService;

		  public GetUserTokenByJwtTokenQueryHandler(IUserQueryService userQueryService)
		  {
			   _userQueryService = userQueryService;
		  }

		  public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
		  {
			   return await _userQueryService.GetUserTokenByJwtToken(request.userId,request.jwtToken);  	
		  }																	 
	 }
}
