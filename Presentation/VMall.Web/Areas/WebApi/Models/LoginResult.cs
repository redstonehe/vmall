﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VMall.Web.Areas.WebApi.Models
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public string Token { get; set; }
    }
}