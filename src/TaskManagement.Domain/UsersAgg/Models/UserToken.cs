using Common.Domain.Exceptions;
using Common.Domain.Models;

namespace TaskManagement.Domain.UsersAgg.Models
{
	 public class UserToken : Entity
	 {


		  public UserToken(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate)
		  {
			   Guard(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate);
			   UserId = userId;
			   HashJwtToken = hashJwtToken;
			   HashRefreshToken = hashRefreshToken;
			   TokenExpireDate = tokenExpireDate;
			   RefreshTokenExpireDate = refreshTokenExpireDate;

		  }
		  public Guid UserId { get; private set; }
		  public string HashJwtToken { get; private set; }
		  public string HashRefreshToken { get; private set; }
		  public DateTime TokenExpireDate { get; private set; }
		  public DateTime RefreshTokenExpireDate { get; private set; }

		  public void Guard(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate)
		  {
			   NullOrEmptyDomainDataException.CheckString(hashJwtToken, nameof(HashJwtToken));
			   NullOrEmptyDomainDataException.CheckString(hashRefreshToken, nameof(HashRefreshToken));

			   if (tokenExpireDate < DateTime.Now)
					throw new InvalidDomainDataException("Invalid Token ExpireDate ");

			   if (refreshTokenExpireDate < tokenExpireDate)
					throw new InvalidDomainDataException("Invalid RefreshToken ExpireDate  ");
		  }

	 }
}
