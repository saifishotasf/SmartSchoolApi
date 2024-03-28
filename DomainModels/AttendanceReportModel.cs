using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class AttendanceReportModel
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string DivisionName { get; set; }
        public string UsersName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public bool isPresent { get; set; }
    }
    
}
