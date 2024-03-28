using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.Token
{
    public class TokenRequest
    {
        [Required(ErrorMessage ="User name required.")]
        public string UserName { get; set; } = string.Empty;


        [Required(ErrorMessage ="Password required.")]
        public string Password { get; set; } = string.Empty;


        public string? DeviceId { get; set; }
    }
}
