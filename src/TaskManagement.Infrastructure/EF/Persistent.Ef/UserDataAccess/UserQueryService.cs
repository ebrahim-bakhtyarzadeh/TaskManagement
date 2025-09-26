using Common.Application.SecurityUtil;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Users.Queries.DTOs;
using TaskManagement.Application.Users.Queries.Shared;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.UserDataAccess
{
	 public class UserQueryService : IUserQueryService
	 {
		  private readonly TaskManagementContext _shopContext;

		  public UserQueryService(TaskManagementContext shopContext)
		  {
			   _shopContext = shopContext;
		  }

		  public async Task<List<UserDto>> GetActiveUsers(CancellationToken cancellationToken)
		  {
			   return await _shopContext.Users
				.Where(c => !c.IsBlockedByAdmin)
		  	 .Select(c => new UserDto
			   {
					Id = c.Id,

					FullName = c.FirstName + c.LastName,
					Email = c.Email,
					Password = c.Password,
					PhoneNumber = c.PhoneNumber,
			   })
		 .ToListAsync(cancellationToken);
		  }

		  public async Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken)
		  {
			   return await _shopContext.Users.Select(c => new UserDto
			   {
					Id = c.Id,
					FullName = c.FirstName + c.LastName,
					Email = c.Email,
					Password = c.Password,
					PhoneNumber = c.PhoneNumber,
					IsBlockedByAdmin = c.IsBlockedByAdmin,
			   }).ToListAsync();
		  }
			public async Task<UserTokenDto> GetUserTokenByJwtToken (Guid userId,string jwtToken)
		  {
			  var user =await _shopContext.Users.Include(c=>c.Tokens).FirstOrDefaultAsync(c => c.Id == userId);
			var token = user.Tokens.FirstOrDefault(c=>c.HashJwtToken == Sha256Hasher.Hash(jwtToken));
			   return new UserTokenDto()
			   {
					UserId = token.UserId,
					HashJwtToken = token.HashJwtToken,
					HashRefreshToken = token.HashRefreshToken,
					RefreshTokenExpireDate = token.RefreshTokenExpireDate,
					TokenExpireDate = token.RefreshTokenExpireDate,

			   };
		  }


		  public async Task<UserDto?> GetUserById(Guid userId, CancellationToken cancellationToken)
		  {
			   return await _shopContext.Users
		.Where(u => u.Id == userId)
		.Select(u => new UserDto
		{
			 Id = u.Id,
			 FullName = u.FirstName + u.LastName,
			 Email = u.Email,
			 Password = u.Password,
			 PhoneNumber = u.PhoneNumber,
			 IsBlockedByAdmin = u.IsBlockedByAdmin,
		})
		.FirstOrDefaultAsync(cancellationToken);
		  }

		  // هشدار زیر مشکلی در پروژه ایجاد نمیکنه طبق قوانین دامنه شماره تلفن نمیتواند خالی باشد .
		  public async Task<UserDto> GetUserByPhoneNumber(string phoneNumber, CancellationToken cancellationToken)
		  {
			   return await _shopContext.Users
.Where(u => u.PhoneNumber == phoneNumber)
.Select(u => new UserDto
{
	 Id = u.Id,
	 FullName = u.FirstName + u.LastName,
	 Email = u.Email,
	 Password = u.Password,
	 PhoneNumber = u.PhoneNumber,
	 IsBlockedByAdmin = u.IsBlockedByAdmin,
})
.FirstOrDefaultAsync(cancellationToken);
		  }

	 }

}
