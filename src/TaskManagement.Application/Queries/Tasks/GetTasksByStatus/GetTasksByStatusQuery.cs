using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.Tasks.DTOs;

namespace TaskManagement.Application.Queries.Tasks.GetTasksByStatus
{
	 public record GetTasksByStatusQuery(Guid userId , TaskStatus status):IRequest<List<TaskDto>>;
}
