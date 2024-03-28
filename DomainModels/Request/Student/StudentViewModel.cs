using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Request.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public byte[] photo { get; set; }
        public string AadhaarNumber { get; set; }
        public byte[]? AadhaarPhoto { get; set; }
        public string MotherName { get; set; }
        public string MotherContact { get; set; }
        public string MotherEmail { get; set; }
        public string? FatherName { get; set; }
        public string FatherContact { get; set; }
        public string FatherEmail { get; set; }
        public string GuardianName { get; set; }
        public string GuardianContact { get; set; }
        public string GuardianEmail { get; set; }
        public StandardView Standard { get; set; }
        public DivisionView Division { get; set; }
        public bool isActive { get; set; }
    }
    public class StandardView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DivisionView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
