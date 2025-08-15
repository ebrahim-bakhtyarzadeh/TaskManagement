using Common.Domain.Exceptions;
using Common.Domain.Models;
using Common.Domain.Validations;
using TaskManagement.Domain.Models.UsersAgg.Constants;
using TaskManagement.Domain.Models.UsersAgg.Services;

namespace TaskManagement.Domain.Models.UsersAgg.Models
{
	 public class User : Entity, IAggregateRoot
	 {
		  public string FirstName { get; private set; }
		  public string LastName { get; private set; }
		  public string Email { get; private set; }
		  public string PhoneNumber { get; private set; }
		  public string Password { get; private set; }
		  public bool IsBlockedByAdmin { get; private set; }
		  public List<UserToken> Tokens { get; private set; }


		  public User(string firstName, string lastName, string email, string phoneNumber, string password, IUserDomainService userDomainService)
		  {
			   Guard(phoneNumber, email, userDomainService);
			   FirstName = firstName;
			   LastName = lastName;
			   Email = email;
			   PhoneNumber = phoneNumber;
			   Password = password;
			   IsBlockedByAdmin = false;
		  }

		  public static User RegisterUser(string email, string phoneNumber, string password, IUserDomainService userDomainService)
		  {
			   return new User("", "", email, phoneNumber, password, userDomainService);
		  }
		  public void Edit(string firstName, string lastName, string phoneNumber, string email, string password, IUserDomainService userDomainService)
		  {
			   Guard(phoneNumber, email, userDomainService);
			   FirstName = firstName;
			   LastName = lastName;
			   PhoneNumber = phoneNumber;
			   Email = email;
			   Password = password;
		  }

		  public void BlockByAdmin()
		  {
			   IsBlockedByAdmin = true;
		  }


		  #region Token
		  public void AddToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate)
		  {
			   var activeTokenCount = Tokens.Count(c => c.RefreshTokenExpireDate > DateTime.Now);
			   if (activeTokenCount >= 3)
			   {
					throw new InvalidDomainDataException("امکان استفاده از سایت با بیشتر از سه دستگاه وجود ندارد . برای دسترسی به سایت از یکی از حساب های خود خارج شوید");
			   }

			   var token = new UserToken(Id, hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate);

			   Tokens.Add(token);
		  }
		  public void RemoveToken(Guid tokenId)
		  {
			   var token = Tokens.FirstOrDefault(c => c.Id == tokenId);

			   if (token == null)
					throw new InvalidDomainDataException("invalid token Id");

			   Tokens.Remove(token);
		  }
		  #endregion



		  public void
			   Guard(string phoneNumber, string email, IUserDomainService userDomainService)
		  {
			   NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));


			   if (UserConstant.User.PhoneNumberLenght != phoneNumber.Length)
			   {
					throw new InvalidDomainDataException("شماره تلفن معتبر نیست");
			   }
			   if (!string.IsNullOrWhiteSpace(email))
					if (email.IsValidEmail() == false)
						 throw new InvalidDomainDataException("آدرس ایمیل صحیح نیست");


			   if (phoneNumber != PhoneNumber)
			   {
					if (userDomainService.PhoneNumberIsExist(phoneNumber))
					{
						 throw new InvalidDomainDataException("حسابی با این شماره قبلا ثبت شده است");
					}
			   }


			   if (email != Email)
					if (userDomainService.IsEmailExist(email))
						 throw new InvalidDomainDataException("حسابی با این ایمیل قبلا ثبت شده است");

		  }


	 }
}
