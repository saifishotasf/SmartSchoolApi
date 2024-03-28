using DomainModels;
using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IStudentAttendanceData
    {
        Task<bool> CreateAttandance(StudentAttendanceDomainModel request);
        IEnumerable<AttendanceViewModel > GetAllAttendances();
        Task<AttendanceViewModel> GetAttendance(AttendanceViewModel request);
        Task<bool> UpdateStudentAttendance(StudentAttendanceDomainModel request);
    }
}
