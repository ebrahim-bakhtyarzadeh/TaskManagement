using Common.Application.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Users.Queries.DTOs;
using TaskManagement.Domain.Models.UsersAgg.Repository;

namespace TaskManagement.Application.Users.Queries.GetById
{
    public record GetUserByIdQuery(Guid userId) : IRequest<QueryResult<UserDto>>;
}
