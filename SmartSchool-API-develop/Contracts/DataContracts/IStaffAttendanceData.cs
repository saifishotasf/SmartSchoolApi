using DomainModels;
using DomainModels.Request.StaffAttendance;
using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IStaffAttendanceData
    {
        Task<bool> CreateStaffAttendance(StaffAttendanceDomainModel request);
        IEnumerable<StaffAttendanceViewModel> GetAllStaffAttendance();
        Task<StaffAttendanceViewModel> GetStaffById(int StaffId);
        Task<bool> UpdateStaffAttendance(StaffAttendanceDomainModel request);
    }
}
