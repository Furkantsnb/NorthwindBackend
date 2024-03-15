﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);   
        }
    }
}
