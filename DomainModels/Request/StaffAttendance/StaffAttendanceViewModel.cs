using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainModels.Request.StaffAttendance
{
    public class StaffAttendanceViewModel
    {
        public StaffViewModel Staff { get; set; }

        public RoleViewModel Role { get; set; }

        public AttendanceTakenByViewModel AttendanceTakenBy { get; set; }

        public DateTime Date { get; set; }

        public string Day { get; set; }

        public bool isPresent { get; set; }

    }
    public class StaffViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }

    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

  
    public class AttendanceTakenByViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
