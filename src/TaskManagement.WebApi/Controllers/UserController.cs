using Common.Application.Result;
using Common.Application.SecurityUtil;
using Common.EndPoint.API;
using Common.EndPoint.API.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands.Users.AddToken;
using TaskManagement.Application.Commands.Users.EditUser;
using TaskManagement.Application.Commands.Users.Register;
using TaskManagement.Application.Queries.Users.DTOs;
using TaskManagement.Application.Queries.Users.GetActiveUsers;
using TaskManagement.Application.Queries.Users.GetAllUsers;
using TaskManagement.Application.Queries.Users.GetById;
using TaskManagement.Application.Queries.Users.GetUserByPhoneNumber;
using TaskManagement.WebApi.DTOs.Auth;
using TaskManagement.WebApi.Infrastructure.JwtUtil;

namespace TaskManagement.WebApi.Controllers
{
    public class UserController : ApiController
    {

        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public UserController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }


          [HttpPost("Register")]
        public async Task<ApiResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }
		  [HttpPut( "Edit")]
		  public async Task<ApiResult> EditUser([FromBody] EditUserCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }
		  [HttpPost("Login")]
		  public async Task<ApiResult<LoginResultDto>> Login([FromBody] LoginDto info)
        {
            var res = await _mediator.Send(new GetUserByPhoneNumberQuery(info.PhoneNumber));
            if (!res.DataIsExist)
            {
                var result = OperationResult<LoginResultDto>.NotFound(res.Message);
                return CommandResult(result);
            }
            if (Sha256Hasher.IsCompare(res.Data.Password, info.Password) == false)
            {
                var result = OperationResult<LoginResultDto>.NotFound("اطلاعات وارد شده معتبر نیست");
                return CommandResult(result);
            }
            if (res.Data.IsBlockedByAdmin == true)
            {
                var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
                return CommandResult(result);
            }
            var loginResult = await AddTokenAndGenerateResult(res.Data);
            return CommandResult(loginResult);
        }
		  [HttpGet("GetActiveUsers")]
		  public async Task<ApiResult<List<UserDto>>> GetActiveUser(CancellationToken cancellationToken)
        {
            var users =await _mediator.Send(new GetActiveUsersQuery());
            return QueryResult(users.Data);
        }
		  [HttpGet("GetAllUser")]
		  public async Task<ApiResult<List<UserDto>>> GetAllUser(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUserQuery());
            return QueryResult(users.Data);
        }
		  [HttpGet("GetUserById")]
		  public async Task<ApiResult<UserDto>> GetUserById(string id,CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetUserByIdQuery(Guid.Parse(id)));
            return QueryResult(users.Data);
        }
		  [HttpGet("GetUserByPhoneNumber")]
		  public async Task<ApiResult<UserDto>> GetUserByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetUserByPhoneNumberQuery(phoneNumber));
            return QueryResult(users.Data);
        }

        [NonAction]
        private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateResult(UserDto user)
        {

            var token = JwtTokenBuilder.BuildToken(user, _configuration);
           
          
            var refreshToken = Guid.NewGuid().ToString();
            var hashJwtToken = Sha256Hasher.Hash(token);
            var hashJwtRefreshToken = Sha256Hasher.Hash(refreshToken);


            var tokenResult = await _mediator.Send(new AddUserTokenCommand(user.Id, hashJwtToken, hashJwtRefreshToken,
                DateTime.Now.AddDays(7), DateTime.Now.AddDays(8)));

            if (tokenResult.Status != OperationResultStatus.Success)
            {
                return OperationResult<LoginResultDto?>.Error();
            }

            return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
            {
                RefreshToken = refreshToken,
                AccessToken = token
            });
        }

    }
}
