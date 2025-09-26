using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Tasks.Queries.DTOs;

namespace TaskManagement.Application.Tasks.Queries.GetTasksByStatus
{
	 public record GetTasksByStatusQuery(Guid userId , TaskStatus status):IRequest<List<TaskDto>>;
}
