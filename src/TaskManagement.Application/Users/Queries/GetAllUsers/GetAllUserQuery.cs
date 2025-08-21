using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Queries.DTOs;

namespace TaskManagement.Application.Users.Queries.GetAllUsers
{
    public record GetAllUserQuery : IRequest<QueryResult<List<UserDto>>>;
}
