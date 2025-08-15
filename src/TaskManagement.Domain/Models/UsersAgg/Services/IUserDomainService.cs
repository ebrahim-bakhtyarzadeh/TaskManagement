namespace TaskManagement.Domain.Models.UsersAgg.Services
{
	 public interface IUserDomainService
	 {
		  bool PhoneNumberIsExist(string phoneNumber);
		  bool IsEmailExist(string email);
	 }
}
