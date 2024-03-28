using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.StudentAttendanceRequest
{
    public class AttendanceViewModel
    {
        public StudentViewModel Student { get; set; }
        public StandardViewModel Standard { get; set; }
        public DivisionViewModel Division { get; set; }
        public UserViewModel User { get; set; }
        public DateTime AttendanceDate { get; set; }
        public bool IsPresent { get; set; }
    }

    public class StudentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StandardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DivisionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
