using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Queries.DTOs;

namespace TaskManagement.Application.Users.Queries.Shared
{
    public interface IUserQueryService
    {
        Task<UserDto?> GetUserById (Guid userId, CancellationToken cancellationToken);
        Task<List<UserDto>> GetActiveUsers( CancellationToken cancellationToken);
        Task<List<UserDto>> GetAllUsers( CancellationToken cancellationToken);
        Task<UserDto> GetUserByPhoneNumber(string phoneNumber, CancellationToken cancellationToken);

    }
}
