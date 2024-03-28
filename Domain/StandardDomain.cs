using System;
using Contracts.DataContracts;
using Contracts.DomainContracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Request.Standard;

namespace Domain
{
    public class StandardDomain : IStandard
    {
        private readonly IStandardData _StandardData;

        public StandardDomain(IStandardData standardData)
        {
            _StandardData = standardData;
        }
        public async Task<bool> CreateStandard(StandardRequest request)
        {
            var domainModel = new StandardDomainModel
            {
                Id = request.Id,
                Name = request.Name,
                Fees = request.Fees
            };
            return await _StandardData.CreateStandard(domainModel);
        }

        public IEnumerable<StandardRequest> GetAllStandards()
        {
            return _StandardData.GetAllStandards();
        }

        public async Task<StandardDomainModel> GetStandard(int StandardId)
        {
            return await _StandardData.GetStandard(StandardId);

        }

        public async Task<bool> UpdateStandard(StandardRequest request)
        {
            var dominModel = new StandardDomainModel
            {
                Id = request.Id,
                Name = request.Name,
                Fees = request.Fees
            };

            return await _StandardData.UpdateStandard(dominModel);
        }


        public async Task<bool> DeleteStandard(int Id)
        {
            return await _StandardData.DeleteStandard(Id);

        }
    }
   
}
