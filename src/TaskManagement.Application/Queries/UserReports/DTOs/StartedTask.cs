namespace TaskManagement.Application.Queries.UserReports.DTOs
{
	public class StartedTask
	{
		public Guid UserId { get; set; }
		public string FullName { get; set; }
		public List<CompletedTaskData> TasksData { get; set; }
	}
}
