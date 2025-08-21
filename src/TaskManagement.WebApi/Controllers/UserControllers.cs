using Application.Common.SecurityUtil;
using Common.EndPoint.API;
using Common.EndPoint.API.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TaskManagement.Application.Users.Commands.AddToken;
using TaskManagement.Application.Users.Commands.EditUser;
using TaskManagement.Application.Users.Commands.Register;
using TaskManagement.WebApi.DTOs.Auth;

namespace TaskManagement.WebApi.Controllers
{
    public class UserControllers:ApiController
    {

        private readonly IMediator _mediator;

        public UserControllers(IMediator mediator)
        {
            _mediator = mediator;
        }



        public async Task<ApiResult> RegisterUser(RegisterUserCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }
        public async Task<ApiResult> EditUser(EditUserCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }

        public async Task<ApiResult> Login (LoginDto info)
        {

        }



        [NonAction]
        private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateResult(UserDto user)
        {

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var userDevice = "windows";
            var header = HttpContext.Response.Headers["user-agent"].ToString();
            var uaParser = Parser.GetDefault();
            if (header != null)
            {
                var info = uaParser.Parse(HttpContext.Request.Headers["user-agent"]);
                userDevice = $"{info.Device.Family} / {info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";

            }
            var refreshToken = Guid.NewGuid().ToString();
            var hashJwtToken = Sha256Hasher.Hash(token);
            var hashJwtRefreshToken = Sha256Hasher.Hash(refreshToken);


            var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwtToken, hashJwtRefreshToken,
                DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), userDevice));

            if (tokenResult.Status != OperationResultStatus.Success)
                return OperationResult<LoginResultDto?>.Error();
            return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
            {
                RefreshToken = refreshToken,
                AccessToken = token
            });
        }

    }
}
