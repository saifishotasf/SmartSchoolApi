using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class Dashboard
    {
        public int TotalStudents { get; set; }
        public int TotalTeachers { get; set; }
        public double TotalEarnings { get; set; }
        public int StudentsLeft { get; set; }
        public int TeachersLeft { get; set; }
        public bool HasLaboratory { get; set; }
        public IEnumerable<MonthlyAttendanceOverview> MonthlyOverview { get; set; }
        public YearlyAttendanceOverview YearlyOverview { get; set; }

    }
    public class MonthlyAttendanceOverview
    {
        public int CountOfStudents { get; set; }
        public int CountOfTeachers { get; set; }
        public string Month { get; set; }
    }
    public class YearlyAttendanceOverview
    {
        public int CountOfStudents { get; set; }
        public int CountOfTeachers { get; set; }
        public int Year { get; set; }
    }
}
