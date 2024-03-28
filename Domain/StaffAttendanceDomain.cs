using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.StaffAttendance;
using DomainModels.Request.StudentAttendanceRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StaffAttendanceDomain : IStaffAttendance
    {
        private readonly IStaffAttendanceData _staffAttendanceData;

        public StaffAttendanceDomain(IStaffAttendanceData staffAttendanceData)
        {
            _staffAttendanceData = staffAttendanceData;
        }

        public Task<bool> CreateStaffAttendance(StaffAttendanceRequest request)
        {
            var domainModel = new StaffAttendanceDomainModel
            {
                StaffId = request.StaffId,
                AttendanceTakenBy = request.AttendanceTakenBy,
                Date=request.Date,
                RoleId=request.RoleId,
                Day=request.Day,
                isPresent=request.isPresent
            };
            return _staffAttendanceData.CreateStaffAttendance(domainModel);
        }

        public IEnumerable<StaffAttendanceViewModel> GetAllStaffAttendance()
        {
            return _staffAttendanceData.GetAllStaffAttendance();
        }

        public Task<StaffAttendanceViewModel> GetStaffById(int StaffId)
        {
           
            return  _staffAttendanceData.GetStaffById(StaffId);
        }

        public Task<bool> UpdateStaffAttendance(StaffAttendanceRequest request)
        {
            var domainModel = new StaffAttendanceDomainModel
            {
                StaffId = request.StaffId,
                AttendanceTakenBy = request.AttendanceTakenBy,
                Date = request.Date,
                RoleId = request.RoleId,
                Day = request.Day,
                isPresent = request.isPresent
            };
            return _staffAttendanceData.UpdateStaffAttendance(domainModel);
        }
    }
}
