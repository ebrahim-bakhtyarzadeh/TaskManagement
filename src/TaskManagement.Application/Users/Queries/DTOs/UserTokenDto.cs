namespace TaskManagement.Application.Users.Queries.DTOs
{
    public class UserTokenDto
    {
        public long UserId { get; set; }
        public string HashJwtToken { get; private set; }
        public string HashRefreshToken { get; private set; }
        public DateTime TokenExpireDate { get; private set; }
        public DateTime RefreshTokenExpireDate { get; private set; }
    }
}
