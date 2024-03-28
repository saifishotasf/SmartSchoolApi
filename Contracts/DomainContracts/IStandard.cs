using DomainModels;
using DomainModels.Request.Institute;
using DomainModels.Request.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IStandard
    {
        Task<bool> CreateStandard(StandardRequest request);
        IEnumerable<StandardRequest> GetAllStandards();
        Task<StandardDomainModel> GetStandard(int StandardId);
        Task<bool> UpdateStandard(StandardRequest request);
        Task<bool> DeleteStandard(int Id);
    }
}
