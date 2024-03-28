using DomainModels.Request.User;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.TimeTableManagement;

namespace Contracts.DataContracts
{
    public interface ITimeTableManagementData
    {
        Task<TimeTableManagementDomainModel> CreateTimeTableManagement(TimeTableManagementDomainModel request);
        IEnumerable<TimeTableManagementViewModel> GetAllTimeTableManagement();

        Task<bool> UpdateTimeTableManagement(TimeTableManagementDomainModel request);
        Task<TimeTableManagementViewModel> GetTimeTableManagementById(long Id);
        Task<bool> DeleteTimeTableManagement(int TimeTableManagementId);




    }
}
