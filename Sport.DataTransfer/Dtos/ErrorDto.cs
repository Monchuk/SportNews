using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.DataTransfer.Dtos
{
    public class ErrorDto<T>
    {
        
        public ErrorDto(string message)
        {
            Message= message;
        }
        public ErrorDto(string message, T errors): this(message) 
        {
            Errors = errors;
        }

        public string Message { get; set; } = string.Empty;
        public T? Errors{ get; set; }

    }
}
