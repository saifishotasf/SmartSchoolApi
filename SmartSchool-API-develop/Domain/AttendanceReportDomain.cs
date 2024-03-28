using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using System.Collections.Generic;

namespace Domain
{
    public class AttendanceReportDomain : IAttendanceReport
    {
        private readonly IAttendanceReportData _attendanceReportData;

        public AttendanceReportDomain(IAttendanceReportData attendanceReportData)
        {
            _attendanceReportData = attendanceReportData;
        }

        public IEnumerable<AttendanceReportModel> GetAttendanceReportData()
        {
            return _attendanceReportData.GetAttendanceReportData();
        }
    }
}
