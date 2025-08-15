using Common.Domain.Models;
using TaskManagement.Domain.Models.TasksAgg.Constants;

namespace TaskManagement.Domain.Models.TasksAgg.Models
{
	 // aggregate root
	 public class WorkItem : Entity, IAggregateRoot
	 {
		  public string Name { get; private set; }
		  public string Description { get; private set; }
		  public DateTime StartTime { get; private set; }
		  public TaskStatus Status { get; private set; }
		  public List<CheckListItem>? Items { get; private set; }

		  public WorkItem(string name, string description, DateTime startTime)
		  {
			   Name = name;
			   Description = description;
			   StartTime = startTime;
			   Status = TaskStatus.NotStarted;
			   Items = new List<CheckListItem>();
		  }
		  public WorkItem UpdateName(string name)
		  {
			   Name = name;
			   return this;
		  }
		  public WorkItem UpdateDescription(string description)
		  {
			   Description = description;
			   return this;
		  }
		  public WorkItem AddCheckListItem(string itemName, string itemDescription, Priority priority)
		  {
			   ValidateCheckListItemQuantity();
			   var item = new CheckListItem(Id, itemName, itemDescription, priority);
			   Items?.Add(item);
			   StatusChecker();

			   return this;
		  }
		  public WorkItem UpdateCheckListItem(Guid itemId, string itemName, string itemDescription, Priority priority)
		  {
			   var checkListitem = Items?.FirstOrDefault(c => c.Id == itemId);
			   if (checkListitem == null)
					throw new ArgumentException("ایتم مورد نظر یافت نشد");

			   checkListitem.UpdateDescription(Description);
			   checkListitem.UpdateName(itemName);
			   checkListitem.UpdatePriority(priority);
			   return this;

		  }
		  public WorkItem RemoveCheckListitem(Guid itemId)
		  {
			   var checkListitem = Items?.FirstOrDefault(c => c.Id == itemId);
			   if (checkListitem == null)
					throw new ArgumentException("ایتم مورد نظر یافت نشد");
			   Items?.Remove(checkListitem);
			   StatusChecker();
			   return this;
		  }
		  public WorkItem MarkCheckListItemAsCompleted(Guid ItemId)
		  {
			   var CurrentItem = Items?.FirstOrDefault(c => c.Id == ItemId);
			   if (CurrentItem == null)
			   {
					throw new ArgumentException("ایتم مورد نظر یافت نشد");
			   }
			   CurrentItem.CheckListItemCompleted();
			   StatusChecker();

			   return this;
		  }

		  public void StatusChecker()
		  {
			   // شیوه ی مورد نظر برای تغییر وضعیت وظیفه بین سه حالت کاملا اختیاری بوده . دلیل این شیوه برای مدیریت زمان بوده است شیوه های متنوعی مثل در نظر گرفتن تاریخ در تغییر وضعیت انتخاب خوبی میتوانست باشد

			   if (Items?.Count == 0)
			   {
					Status = TaskStatus.NotStarted;
			   }
			   if (Items?.Count > 0 && Items.Any(c => c.IsCompleted == false) == false)
			   {
					Status = TaskStatus.InProgress;

			   }
			   if (Items?.Count > 0 && Items.Any(c => c.IsCompleted == false) == true)
			   {
					Status = TaskStatus.Completed;

			   }
		  }
		  private void ValidateCheckListItemQuantity()
		  {
			   if (TaskConstant.Task.MaxItemQuantity == Items?.Count)
			   {
					throw new ArgumentException($"تعداد چک لیست ایتم های شما باید بین {TaskConstant.Task.MinItemQuantity} و {TaskConstant.Task.MaxItemQuantity} باشد");
			   }
		  }
	 }
}
