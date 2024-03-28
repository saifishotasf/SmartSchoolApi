using DomainModels;
using DomainModels.Request.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IStandardData
    {
        Task<bool> CreateStandard(StandardDomainModel request);
        IEnumerable<StandardRequest> GetAllStandards();
        Task<StandardDomainModel> GetStandard(int StandardId);
        Task<bool> UpdateStandard(StandardDomainModel request);
        Task<bool> DeleteStandard(int Id);
    }
}
