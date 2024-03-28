using DomainModels;
using DomainModels.Request.StaffAttendance;
using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IStaffAttendance
    {
        Task<bool> CreateStaffAttendance(StaffAttendanceRequest request);
        IEnumerable<StaffAttendanceViewModel> GetAllStaffAttendance();
        Task<StaffAttendanceViewModel> GetStaffById(int StaffId);
        Task<bool> UpdateStaffAttendance(StaffAttendanceRequest request);

    }
}
