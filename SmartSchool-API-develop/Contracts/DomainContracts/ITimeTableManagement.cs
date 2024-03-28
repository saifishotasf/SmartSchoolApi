using DomainModels.Request.User;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.TimeTableManagement;
using DomainModels.Request.Student;

namespace Contracts.DomainContracts
{
    public interface ITimeTableManagement
    {
        Task<TimeTableManagementDomainModel> CreateTimeTableManagement(TimeTableManagementRequest request);
        IEnumerable<TimeTableManagementViewModel> GetAllTimeTableManagement();
        Task<bool> UpdateTimeTableManagement(TimeTableManagementRequest request);
        Task<TimeTableManagementViewModel> GetTimeTableManagementById(long Id);
        Task<bool> DeleteTimeTableManagement(int TimeTableManagementId);



    }
}
