using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.StudentAttendanceRequest
{
    
    public class GetAttendanceById
    {
        public int StudentId { get; set; }
        public DateTime AttendanceDate { get; set; }
        
    }
}
