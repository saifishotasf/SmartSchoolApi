
using Microsoft.AspNetCore.Http;

namespace Utility.GlobalErrorHandling
{
    public class APIExceptions : Exception
    {
        public APIExceptions(string message) : base(message) 
        { }

        public APIExceptions(string message, int statusCode) : base(message)
        { 
            
        }
    }
}
