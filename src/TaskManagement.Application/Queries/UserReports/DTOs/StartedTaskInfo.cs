namespace TaskManagement.Application.Queries.UserReports.DTOs
{
	public class StartedTaskInfo
	{
		public Guid UserId { get; set; }
		public string FullName { get; set; }
		  public Guid TaskId { get; set; }
		  public string TaskName { get; set; }
		  public int CheckListItemCount { get; set; }
	 }
}
