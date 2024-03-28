using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Institute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IInstituteData
    {
        Task<bool> CreateInstitute(InstituteDomainModel request);
        Task<bool> UpdateInstitute(InstituteUpdateDomainModel request);
        Task<bool> DeleteInstitute(long Id);
        IEnumerable<InstituteRequest> GetAllInstitutes();
        Task<InstituteDomainModel> GetInstitute(long InstituteId);
    }
}
