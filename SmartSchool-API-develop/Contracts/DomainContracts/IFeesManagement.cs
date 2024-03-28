using DomainModels.Request.TimeTableManagement;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.FeesManagement;

namespace Contracts.DomainContracts
{
    public interface IFeesManagement
    {
        Task<FeesManagementModel> CreateFeesManagement(FeesManagementRequest request);
        IEnumerable<FeesManagementViewModel> GetAllFeesManagement();
        Task<bool> UpdateFeesManagement(FeesManagementRequest request);
        Task<FeesManagementViewModel> GetFeesManagementById(int StudentId);
        Task<bool> DeleteFeesManagement(int StudentId);

    }
}
