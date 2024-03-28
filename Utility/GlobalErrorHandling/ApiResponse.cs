using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.GlobalErrorHandling
{
    public partial class ApiResponse<T>
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public ApiResponse() { }


        /// <summary>
        /// Represents API success response.
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="message">error message</param>
        public ApiResponse(T data, string message = null)
        {
            IsSuccess = false;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Failed response
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="statusCode">statusCode</param>
        public ApiResponse(string message,int statusCode) 
        { 
            IsSuccess = false;
            Message = message;
            StatusCode = statusCode;
        }



        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
