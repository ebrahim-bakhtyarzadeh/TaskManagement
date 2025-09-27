namespace TaskManagement.Application.Commands.Users.Common
{
	 public class UserToken
	 {
		  public UserToken(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate)
		  {
			   UserId = userId;
			   HashJwtToken = hashJwtToken;
			   HashRefreshToken = hashRefreshToken;
			   TokenExpireDate = tokenExpireDate;
			   RefreshTokenExpireDate = refreshTokenExpireDate;
		  }

		  public Guid UserId { get; }
		  public string HashJwtToken { get; }
		  public string HashRefreshToken { get; }
		  public DateTime TokenExpireDate { get; }
		  public DateTime RefreshTokenExpireDate { get; }
	 }
}
