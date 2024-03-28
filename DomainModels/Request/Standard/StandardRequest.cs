using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.Standard
{
    public class StandardRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fees { get; set; }
    }
}
