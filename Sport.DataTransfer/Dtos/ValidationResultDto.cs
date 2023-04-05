using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.DataTransfer.Dtos
{
    public class ValidationResultDto: ErrorDto<IDictionary<string,string>>
    {
        public ValidationResultDto(IDictionary<string,string> errors): base("Validation failed", errors)
        {
          
        }
    }
}
