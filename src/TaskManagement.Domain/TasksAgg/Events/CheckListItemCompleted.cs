using Common.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.TasksAgg.Events
{
	 public class CheckListItemCompleted   :IDomainEvent
	 {
		  public Guid TaskId { get; set; }
		  public Guid CheckListitemId { get; set; }
		  public Guid UserId { get; set; }
	 }
}
