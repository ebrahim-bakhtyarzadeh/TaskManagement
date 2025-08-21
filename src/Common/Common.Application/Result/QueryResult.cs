using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.Result
{
    public class QueryResult<T>
    {
        public bool DataIsExist { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; private set; }

        private QueryResult(bool dataIsExist, string message, T? data)
        {
            DataIsExist = dataIsExist;
            Message = message;
            Data = data;
        }

        
        public static QueryResult<T> Success(T data, string message = "داده مورد نظر یافت شد")
        {
            return new QueryResult<T>(true, message, data);
        }

        public static QueryResult<T> Failure(string message = "دیتا یافت نشد !")
        {
            return new QueryResult<T>(false, message, default);
        }
    }



    
}
