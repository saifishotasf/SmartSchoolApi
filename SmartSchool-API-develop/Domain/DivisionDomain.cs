using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Request.Division;

namespace Domain
{
    public class DivisionDomain : IDivision
    {
        private readonly IDivisionData _divisionData;

        public DivisionDomain(IDivisionData divisionData)
        {
            _divisionData = divisionData;
        }

        public async Task<bool> CreateDivision(DivisionRequest request)
        {
            var domainModel = new DivisionDomainModel
            {
                Id = request.Id,
                Name = request.Name,
            };
            return await _divisionData.CreateDivision(domainModel);
        }

        public IEnumerable<DivisionRequest> GetAllDivisions()
        {
            return _divisionData.GetAllDivisions();
        }

        public Task<DivisionDomainModel> GetDivision(int DivId)
        {
            return _divisionData.GetDivision(DivId);
        }

        public async Task<bool> UpdateDivision(DivisionRequest request)
        {
            var dominModel = new DivisionDomainModel
            {
                Id = request.Id,
                Name = request.Name,
            };

            return await _divisionData.UpdateDivision(dominModel);
        }

        public Task<bool> DeleteDivioson(int DivId)
        {
            return _divisionData.DeleteDivioson(DivId);
        }
    }
}
