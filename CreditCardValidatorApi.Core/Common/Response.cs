using System;
using System.Collections.Generic;
using System.Text;

namespace CreditCardValidatorApi.Core.Common
{
    public class Response 
    {
        public string Status { get; set; }
        public List<string> Message { get; set; }
        public List<Error> ErrorMessages { get; set; }
        public object Data { get; set; }
    }
}
