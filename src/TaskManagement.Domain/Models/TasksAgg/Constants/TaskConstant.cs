namespace TaskManagement.Domain.Models.TasksAgg.Constants
{
	 public class TaskConstant
	 {
		  public class CheckListItem
		  {

			   public const int MinNameLength = 2;
			   public const int MaxNameLength = 50;
			   public const int MinDescriptionLength = 2;
			   public const int MaxDescriptionLength = 500;

		  }
		  public class Task
		  {
			   public const int MinNameLength = 2;
			   public const int MaxNameLength = 50;
			   public const int MinDescriptionLength = 2;
			   public const int MaxDescriptionLength = 500;
			   public const int MinItemQuantity = 0;
			   public const int MaxItemQuantity = 10;
		  }
	 }
}
