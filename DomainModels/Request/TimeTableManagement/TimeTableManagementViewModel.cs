using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.TimeTableManagement
{
    public  class TimeTableManagementViewModel
    {
        public long? Id { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public int? DurationOfLecture { get; set; }
        public string TimeTableName { get; set; }
        public string? description { get; set; }
        public bool? isActive { get; set; }
        public StandardView? Standard { get; set; }
        public TeacherView? Teacher { get; set; }
        public SubjectView? Subject { get; set; }
        public string? Day { get; set; }


    }
    public class StandardView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TeacherView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
