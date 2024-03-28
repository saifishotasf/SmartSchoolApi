using DomainModels;
using DomainModels.Request.Division;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DataContracts
{
    public interface IDivisionData
    {

        Task<bool> CreateDivision(DivisionDomainModel request);
        IEnumerable<DivisionRequest> GetAllDivisions();
        Task<DivisionDomainModel> GetDivision(int DivId);
        Task<bool> UpdateDivision(DivisionDomainModel request);
        Task<bool> DeleteDivioson(int DivId);
    }
}
