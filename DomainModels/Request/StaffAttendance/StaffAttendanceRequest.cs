using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.StaffAttendance
{
    public class StaffAttendanceRequest
    {
        public int Id { get; set; }

        public int StaffId { get; set; }

        public int AttendanceTakenBy { get; set; }

        public DateTime Date { get; set; }

        public int RoleId { get; set; }

        public string Day { get; set; }

        public bool isPresent { get; set; }

    }
}
