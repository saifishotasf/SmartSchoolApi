using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.StudentAttendanceRequest
{
    public class StudentAttendanceRequest
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StandarId  { get; set; }
        public int DivisionId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
