using Microsoft.AspNetCore.Mvc;
using Sport.DataTransfer.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sport.DataTransfer.Responses
{
    public class ErrorResult : ObjectResult
    {
        public ErrorResult(string message): base(new ErrorDto<IDictionary>(message)) 
        {
                
        }

        public ErrorResult(string message, int statusCode) : this(message) 
        {
                StatusCode= statusCode;
        }

        public ErrorResult(string message, int statusCode, IDictionary errors): base(new ErrorDto<IDictionary>(message,errors)) 
        {
            StatusCode= statusCode;
        }

        public override string ToString()
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            return JsonSerializer.Serialize(Value,options);
        }
    }
}
