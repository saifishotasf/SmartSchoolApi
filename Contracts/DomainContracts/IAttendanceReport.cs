using Contracts.DataContracts;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IAttendanceReport
    {
        IEnumerable<AttendanceReportModel> GetAttendanceReportData();
    }
}
