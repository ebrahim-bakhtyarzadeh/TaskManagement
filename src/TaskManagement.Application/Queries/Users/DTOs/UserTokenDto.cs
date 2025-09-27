namespace TaskManagement.Application.Queries.Users.DTOs
{
    public class UserTokenDto
    {
        public Guid UserId { get; set; }
        public string HashJwtToken { get; set; }
        public string HashRefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
