using DomainModels;
using DomainModels.Request.Student;
using DomainModels.Request.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IStudent
    {
        Task<bool> CreateStudent(StudentRequest request);
        IEnumerable<StudentViewModel> GetAllStudents();
        Task<StudentViewModel> GetStudent(int StudentId);
        Task<bool> UpdateStudent(StudentRequest request);
        Task<bool> DeleteStudent(int StudentId);
    }
}
