using Contracts.DataContracts;
using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IStudentAttendance 
    {
        Task<bool> CreateAttandance(StudentAttendanceRequest request);
        IEnumerable<AttendanceViewModel> GetAllAttendances();
        Task<AttendanceViewModel> GetAttendance(GetAttendanceById request);
        Task<bool> UpdateStudentAttendance(UpdateAttendanceRequest request);
    }
}
