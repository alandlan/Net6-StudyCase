using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedKernel.Responses
{
    public class ResponseDetails
    {
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}