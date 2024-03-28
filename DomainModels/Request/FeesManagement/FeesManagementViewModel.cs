using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.FeesManagement
{
    public  class FeesManagementViewModel
    {
        public int StudentId { get; set; }
        public double Fees { get; set; }
        public double PendingFees { get; set; }
        public double PaidFees { get; set; }
        public DateTime Date { get; set; }
        public StudentView? Student { get; set; }
        public StandardsView? Standards { get; set; }
        public TeachersView? Teachers { get; set; }
        public DevisionView? Devision { get; set; }
        public bool isActive { get; set; }
    }
    public class StudentView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StandardsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class TeachersView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DevisionView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
