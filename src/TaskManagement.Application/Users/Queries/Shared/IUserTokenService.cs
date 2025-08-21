using TaskManagement.Application.Users.Commands.Common;

namespace TaskManagement.Application.Users.Queries.Shared
{
    public interface IUserTokenService
    {
        // اوردن تعداد اکانت های فعال با توجه به توکن های فعالی که داره 
        Task<int> NumberOfActiveAccount( Guid userId, CancellationToken cancellationToken);
        Task<UserToken> GetByJWtToken(string hashJwtToken, CancellationToken cancellationToken);
    }
}
