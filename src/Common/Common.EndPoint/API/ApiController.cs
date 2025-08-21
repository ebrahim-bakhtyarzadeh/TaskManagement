using Application.Common.Result;
using Common.EndPoint.API.Result;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.EndPoint.API
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController: ControllerBase
    {
        protected ApiResult CommandResult(UseCaseResult result)
        {
            return new ApiResult()
            {
                IsSuccess = result.Status == UseCaseStatus.Success,
                MetaData = new()
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapOperationStatus()
                }
            };
        }

        protected ApiResult<TData?> CommandResult<TData>(UseCaseResult<TData> result, HttpStatusCode statusCode = HttpStatusCode.OK, string locationUrl = null)
        {
            bool isSuccess = result.Status == UseCaseStatus.Success;

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
        public static AppStatusCode MapOperationStatus(this UseCaseStatus status)
        {
            switch (status)
            {
                case UseCaseStatus.Success:
                    return AppStatusCode.Success;

                case UseCaseStatus.NotFound:
                    return AppStatusCode.NotFound;

                case UseCaseStatus.Error:
                    return AppStatusCode.Error;

            }
            return AppStatusCode.Error;
        }
    }
}
