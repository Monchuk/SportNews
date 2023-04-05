using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Business.Exceptions
{
    public class IdentityErrorException : AppException
    {
        public IdentityErrorException(string message) : base(message)
        {
        }

        public IdentityErrorException(ExceptionMessage exceptionMessage) : base(exceptionMessage)
        {
        }

        public IdentityErrorException(ExceptionMessage exceptionMessage,IEnumerable<IdentityError> identityErrors) : this(exceptionMessage)
        {
            foreach (var identityError in identityErrors)
            {
                AddParam(identityError);
            }
            
        }
    }
}
