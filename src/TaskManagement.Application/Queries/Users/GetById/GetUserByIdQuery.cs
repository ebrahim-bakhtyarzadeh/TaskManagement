using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.Users.DTOs;

namespace TaskManagement.Application.Queries.Users.GetById
{
    public record GetUserByIdQuery(Guid userId) : IRequest<QueryResult<UserDto>>;
}
