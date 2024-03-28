using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.StudentAttendanceRequest
{
    public class UpdateAttendanceRequest
    {
        public int StudentId { get; set; }
        public int DivisionId { get; set; }
        public int StandardId { get; set; }
        public long UserId { get; set; }
        public string DateOfAttendance { get; set; }
        public bool IsPresent { get; set; }
    }
}
