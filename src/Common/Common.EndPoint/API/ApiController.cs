using Common.Application.Result;
using Common.EndPoint.API.Result;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Common.EndPoint.API
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult result)
        {
            return new ApiResult()
            {
                IsSuccess = result.Status == OperationResultStatus.Success,
                MetaData = new()
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapOperationStatus()
                }
            };
        }

        protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result, HttpStatusCode statusCode = HttpStatusCode.OK, string locationUrl = null)
        {
            bool isSuccess = result.Status == OperationResultStatus.Success;

            if (isSuccess)
            {
                HttpContext.Response.StatusCode = (int)statusCode;
                if (!string.IsNullOrWhiteSpace(locationUrl))
                {
                    HttpContext.Response.Headers.Add("location", locationUrl);
                }
            }
            return new ApiResult<TData?>()
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? result.Data : default,
                MetaData = new()
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapOperationStatus()
                }
            };
        }
        protected ApiResult<TData?> QueryResult<TData>(TData? result)
        {

            return new ApiResult<TData?>()
            {
                IsSuccess = true,
                Data = result,
                MetaData = new()
                {
                    Message = "عملیات انجام شد",
                    StatusCode = AppStatusCode.Success
                }
            };
        }
    }
    public static class EnumHelper
    {
        public static AppStatusCode MapOperationStatus(this OperationResultStatus status)
        {
            switch (status)
            {
                case OperationResultStatus.Success:
                    return AppStatusCode.Success;

                case OperationResultStatus.NotFound:
                    return AppStatusCode.NotFound;

                case OperationResultStatus.Error:
                    return AppStatusCode.Error;

            }
            return AppStatusCode.Error;
        }
    }
}
