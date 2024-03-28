using DomainModels;
using DomainModels.Request.Division;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.DomainContracts
{
    public interface IDivision
    {

        Task<bool> CreateDivision(DivisionRequest request);
        IEnumerable<DivisionRequest> GetAllDivisions();
        Task<DivisionDomainModel> GetDivision(int DivId);
        Task<bool> UpdateDivision(DivisionRequest request);
        Task<bool> DeleteDivioson(int DivId);
    }
}
