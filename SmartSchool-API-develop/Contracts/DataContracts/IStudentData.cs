using DomainModels;
using DomainModels.Request.Student;
using DomainModels.Request.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IStudentData
    {
        Task<bool> CreateStudent(StudentDomainModel request);
        IEnumerable<StudentViewModel> GetAllStudents();
        Task<StudentViewModel> GetStudent(int StudentId);
        Task<bool> UpdateStudent(StudentDomainModel request);
        Task<bool> DeleteStudent(int StudentId);
    }
}
