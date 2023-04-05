using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sport.DataTransfer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.DataTransfer.Responses
{
    public class ValidationFailedResult: ObjectResult
    {
        public ValidationFailedResult(IDictionary<string, string> errors) : base(new ValidationResultDto(errors))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }
}
