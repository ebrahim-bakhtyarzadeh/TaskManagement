using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EndPoint.API.Result
{
    public class ApiResult
    {
        public MetaData MetaData { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class ApiResult<T> 
    {

        public MetaData MetaData { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

    }
    public class MetaData
    {
        public string Message { get; set; }
        public AppStatusCode StatusCode { get; set; }
    }


public enum AppStatusCode
{
    Success = 200, NotFound = 404, Error = 500,BadRequest = 400

}}
