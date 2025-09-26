using TaskManagement.Domain.UsersAgg.Repository;
using TaskManagement.Domain.UsersAgg.Services;

namespace TaskManagement.Application.Users.Commands
{
	 public class UserDomainService : IUserDomainService
	 {
		  IUserRepository _repo;

		  public UserDomainService(IUserRepository repo)
		  {
			   _repo = repo;
		  }

		  public bool EmailIsExist(string email)
		  {
			   return _repo.Exists(c => c.Email == email);
		  }

		  public bool PhoneNumberIsExist(string phoneNumber)
		  {
			   return _repo.Exists(c => c.PhoneNumber == phoneNumber);
		  }
	 }
}
