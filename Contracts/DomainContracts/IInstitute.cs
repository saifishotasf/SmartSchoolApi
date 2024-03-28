using DomainModels;
using DomainModels.Request.Institute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IInstitute
    {
        Task<bool> CreateInstitute(InstituteRequest request);
        Task<bool> UpdateInstitute(InstituteUpdateRequest request);
        IEnumerable<InstituteRequest> GetAllInstitutes();
        Task<InstituteDomainModel> GetInstitute(long InstituteId);
        Task<bool> DeleteInstitute(long Id);
    }
}
