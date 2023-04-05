using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Business.Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public override IDictionary Data => _errors;

        private readonly Dictionary<string, object?> _errors = new();

        public AppException(string message): base(message) 
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
        public AppException(ExceptionMessage exceptionMessage): this(exceptionMessage.Message) 
        {
            StatusCode=exceptionMessage.StatusCode;
        }


        public AppException AddParam(string key, string? value) 
        {
            if (_errors.ContainsKey(key))
            {
                _errors[key] = string.Join(" ", _errors[key], value);
            }
            else 
            {
                _errors.Add(key,value);
            }

            return this;
        }
        public AppException AddParam(string key, bool value)
        {
            if (_errors.ContainsKey(key))
            {
                _errors[key] = value;
            }
            else
            {
                _errors.Add(key, value);
            }

            return this;
        }

        public AppException AddParam(IdentityError identityError)
        {
            AddParam(identityError.Code,identityError.Description);

            return this;
        }

    }
}
