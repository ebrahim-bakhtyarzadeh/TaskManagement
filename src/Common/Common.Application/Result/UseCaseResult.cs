namespace Application.Common.Result
{
	 public class UseCaseResult
	 {
		  private const string ErrorMessage = "عملیات با شکست رو به رو شد";
		  private const string SuccessMessage = "عملیات با موفقیت انجام شد";
		  private const string NotFoundMessage = " اطلاعاتی یافت نشد ";
		  private string Message { get; set; }
		  private bool IsSuccess { get; set; } = false;
		  private UseCaseStatus Status { get; set; }


		  public static UseCaseResult Error()
		  {
			   return new UseCaseResult()
			   {
					Status = UseCaseStatus.Error,
					Message = ErrorMessage,
			   };
		  }
		  public static UseCaseResult Error(string message)
		  {
			   return new UseCaseResult()
			   {
					Status = UseCaseStatus.Error,
					Message = message,
			   };
		  }
		  public static UseCaseResult NotFound(string message)
		  {
			   return new UseCaseResult()
			   {
					Status = UseCaseStatus.NotFound,
					Message = message,

			   };
		  }
		  public static UseCaseResult NotFound()
		  {
			   return new UseCaseResult()
			   {
					Status = UseCaseStatus.NotFound,
					Message = NotFoundMessage,

			   };
		  }
		  public static UseCaseResult Success()
		  {
			   return new UseCaseResult()
			   {
					Status = UseCaseStatus.Success,
					Message = SuccessMessage,
					IsSuccess = true
			   };
		  }
		  public static UseCaseResult Success(string message)
		  {
			   return new UseCaseResult()
			   {
					Status = UseCaseStatus.Success,
					Message = message,
					IsSuccess = true
			   };
		  }
	 }


	 public class UseCaseResult<TData>
	 {
		  public const string ErrorMessage = "عملیات با شکست رو به رو شد";
		  public const string SuccessMessage = "عملیات با موفقیت انجام شد";
		  public const string NotFoundMessage = " اطلاعاتی یافت نشد ";



		  public string Message { get; set; }
		  public bool IsSuccess { get; set; } = false;
		  public UseCaseStatus Status { get; set; }
		  public TData Data { get; set; }
		  public static UseCaseResult<TData> Error()
		  {
			   return new UseCaseResult<TData>()
			   {
					Status = UseCaseStatus.Error,
					Message = ErrorMessage,
					Data = default(TData)
			   };
		  }
		  public static UseCaseResult<TData> Error(string message)
		  {
			   return new UseCaseResult<TData>()
			   {
					Status = UseCaseStatus.Error,
					Message = message,
					Data = default(TData)

			   };
		  }


		  public static UseCaseResult<TData> NotFound(string message)
		  {
			   return new UseCaseResult<TData>()
			   {
					Status = UseCaseStatus.NotFound,
					Message = message,
					Data = default(TData)
			   };
		  }
		  public static UseCaseResult<TData> NotFound()
		  {

			   return new UseCaseResult<TData>()
			   {
					Message = NotFoundMessage,
					Status = UseCaseStatus.NotFound,
					Data = default(TData)
			   };

		  }

		  public static UseCaseResult<TData> Success()
		  {
			   return new UseCaseResult<TData>()
			   {
					Status = UseCaseStatus.Success,
					Message = SuccessMessage,
					Data = default(TData),
					IsSuccess = true
			   };
		  }
		  public static UseCaseResult<TData> Success(string message)
		  {
			   return new UseCaseResult<TData>()
			   {
					Status = UseCaseStatus.Success,
					Message = message,
					Data = default(TData),
					IsSuccess = true

			   };
		  }



	 }




	 public enum UseCaseStatus
	 {
		  Error = 500,
		  Success = 200,
		  NotFound = 404
	 }
}
