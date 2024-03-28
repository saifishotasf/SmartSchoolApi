using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    public class timetablemanagement

    {
        public long? Id { get; set; }
        public long? StandardId { get; set; }
        public long? TeacherId { get; set; }
        public long? SubjectId { get; set; }
        public DateTime? FromTime{ get; set; }
        public DateTime? ToTime{ get; set; }
        public int? DurationOfLecture { get; set; }
        public string? TimeTableName { get; set; }
        public string? description { get; set; }
        public bool? isActive { get; set; }
        public string? Day { get; set; }



    }
}
