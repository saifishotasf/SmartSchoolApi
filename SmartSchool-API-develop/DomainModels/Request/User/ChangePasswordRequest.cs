﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.User
{
    public class ChangePasswordRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string NewPassword { get; set; } 
    }
}
