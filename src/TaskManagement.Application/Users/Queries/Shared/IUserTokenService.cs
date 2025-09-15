using TaskManagement.Application.Users.Commands.Common;

namespace TaskManagement.Application.Users.Queries.Shared
{
    public interface IUserTokenService
    {
     
        Task<int> NumberOfActiveAccount( Guid userId, CancellationToken cancellationToken);
        Task<UserToken> GetByJWtToken(string hashJwtToken, CancellationToken cancellationToken);
    }
}
