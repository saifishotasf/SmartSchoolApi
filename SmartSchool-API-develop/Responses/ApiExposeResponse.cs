﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Responses
{
    public partial class ApiExposeResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Error { get; set; }
    }
}
