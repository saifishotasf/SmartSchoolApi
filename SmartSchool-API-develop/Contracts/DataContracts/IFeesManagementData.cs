using DomainModels;
using DomainModels.Request.FeesManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IFeesManagementData
    {
        Task<FeesManagementModel> CreateFeesManagement(FeesManagementModel request);
        IEnumerable<FeesManagementViewModel> GetAllFeesManagement();
        Task<bool> UpdateFeesManagement(FeesManagementModel request);
        Task<FeesManagementViewModel> GetFeesManagementById(int StudentId);
        Task<bool> DeleteFeesManagement(int StudentId);
    }
}
