namespace Common.Application.Result
{
    public class OperationResult
    {
        public const string ErrorMessage = "عملیات با شکست رو به رو شد";
        public const string SuccessMessage = "عملیات با موفقیت انجام شد";
        public const string NotFoundMessage = " اطلاعاتی یافت نشد ";
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public OperationResultStatus Status { get; set; }


        public static OperationResult Error()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = ErrorMessage,
            };
        }
        public static OperationResult Error(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Error,
                Message = message,
            };
        }
        public static OperationResult NotFound(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = message,

            };
        }
        public static OperationResult NotFound()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.NotFound,
                Message = NotFoundMessage,

            };
        }
        public static OperationResult Success()
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
                IsSuccess = true
            };
        }
        public static OperationResult Success(string message)
        {
            return new OperationResult()
            {
                Status = OperationResultStatus.Success,
                Message = message,
                IsSuccess = true
            };
        }
    }


    public class OperationResult<TData>
    {
        public const string ErrorMessage = "عملیات با شکست رو به رو شد";
        public const string SuccessMessage = "عملیات با موفقیت انجام شد";
        public const string NotFoundMessage = " اطلاعاتی یافت نشد ";



        public string Message { get; set; }
        public bool IsSuccess { get; set; } = false;
        public OperationResultStatus Status { get; set; }
        public TData Data { get; set; }
        public static OperationResult<TData> Error()
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Error,
                Message = ErrorMessage,
                Data = default
            };
        }
        public static OperationResult<TData> Error(string message)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Error,
                Message = message,
                Data = default

            };
        }


        public static OperationResult<TData> NotFound(string message)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.NotFound,
                Message = message,
                Data = default
            };
        }
        public static OperationResult<TData> NotFound()
        {

            return new OperationResult<TData>()
            {
                Message = NotFoundMessage,
                Status = OperationResultStatus.NotFound,
                Data = default
            };

        }

        public static OperationResult<TData> Success()
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
                Data = default,
                IsSuccess = true
            };
        }
        public static OperationResult<TData> Success(string message)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Success,
                Message = message,
                Data = default,
                IsSuccess = true

            };
        }

        public static OperationResult<TData> Success(TData data)
        {
            return new OperationResult<TData>()
            {
                Status = OperationResultStatus.Success,
                Message = SuccessMessage,
                Data = data, 
                 IsSuccess = true
            };
        }


    }




    public enum OperationResultStatus
    {
        Error = 500,
        Success = 200,
        NotFound = 404
    }
}
