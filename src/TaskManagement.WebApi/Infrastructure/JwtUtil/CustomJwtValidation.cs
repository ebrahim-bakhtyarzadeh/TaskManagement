using Common.EndPoint;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TaskManagement.Application.Users.Queries.GetById;
using TaskManagement.Application.Users.Queries.GetUserTokenByJwtToken;

namespace TaskManagement.WebApi.Infrastructure.JwtUtil
{
	 public class CustomJwtValidation
	 {
		  private readonly IMediator _mediator;

		  public CustomJwtValidation(IMediator mediator)
		  {
			   _mediator = mediator;
		  }

		  public async Task Validate(TokenValidatedContext context)
		  {
			   Guid userId = context.Principal.GetUserId();
			   var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
			   var token = await _mediator.Send(new GetUserTokenByJwtTokenQuery(userId,jwtToken));
			   if (token == null)
			   {
					context.Fail("توکن یافت نشد");
					return;
			   }
			   var user = await _mediator.Send(new GetUserByIdQuery(userId));
			   if (user == null  || user.Data == null|| user.Data.IsBlockedByAdmin == true)
			   {
					context.Fail("توکن یافت نشد");
					return;
			   }
		  }
	 }
}
