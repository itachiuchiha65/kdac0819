﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject1.Models
{
    public class Response
    {
        public String Status { get; set; }
        public Exception Error { get; set; }
        public dynamic Data { get; set; }
    }
}