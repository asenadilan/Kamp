using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result: IResult
    {
        // get read only dir read only constructorda set edilebilir
        public Result(bool success,string message):this(success) //this içindeki parametreyi karşılayan contr çalıştır
        {
            Message = message;
        } 
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; } 
        
    }
}
