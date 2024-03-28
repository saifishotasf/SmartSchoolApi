using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class SubjectDomainModel
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public bool isActive { get; set; }
        public int StandardId { get; set; }
    }
}
