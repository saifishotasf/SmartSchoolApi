using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.Division
{
    public class DivisionRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
       
    }
}
