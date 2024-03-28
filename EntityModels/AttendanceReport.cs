using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModels
{

    [Keyless]
    public class AttendanceReport 
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int DivisionId { get; set; }
        public int UserId { get; set; }    
        public DateTime? Date {  get; set; }
        public bool isPresent { get; set; }
        
    }
}
