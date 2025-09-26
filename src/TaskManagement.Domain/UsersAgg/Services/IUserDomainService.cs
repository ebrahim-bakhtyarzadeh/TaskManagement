namespace TaskManagement.Domain.UsersAgg.Services
{
	 public interface IUserDomainService
	 {
		  bool PhoneNumberIsExist(string phoneNumber);
		  bool EmailIsExist(string email);
	 }
}
