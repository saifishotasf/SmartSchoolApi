using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{
    
    public class StudentAttendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StandardId { get; set; }
        public int DivisionId { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
