using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Business.Exceptions
{
    public class ExceptionMessage
    {
        public ExceptionMessage(string message)
        {
            Message= message;
            StatusCode = StatusCodes.Status400BadRequest;
        }
        public ExceptionMessage(string message , int statusCode) :this(message) 
        {
            StatusCode = statusCode;
        }


        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

    public static class ExceptionMessages 
    {
        public static readonly ExceptionMessage SomethingWentWrong = new ExceptionMessage("Something Went Wrong");
        public static readonly ExceptionMessage ThisEmailNotExist = new ExceptionMessage("This Email Not Exist");
    }
}
