using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Institute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class InstituteDomain : IInstitute
    {
        private readonly IInstituteData _instituteData;
        public InstituteDomain(IInstituteData instituteData)
        {
            _instituteData = instituteData;
        }
        public async Task<bool> CreateInstitute(InstituteRequest request)
        {
            var dominModel = new InstituteDomainModel
            {
                ActivationKey = request.ActivationKey,
                Address = request.Address,
                Branch = request.Branch,
                Contact = request.Contact,
                Email = request.Email,
                isActive = true,
                Logo = request.Logo,
                Name = request.Name,
                RegistrationNumber = request.RegistrationNumber,
                SubscriptionEndDate = request.SubscriptionEndDate,
                SubscriptionStartDate = request.SubscriptionStartDate,
            };

            return await _instituteData.CreateInstitute(dominModel);
        }
        public async Task<bool> UpdateInstitute(InstituteUpdateRequest request)
        {
            var dominModel = new InstituteUpdateDomainModel
            {
                Id = request.Id,
                ActivationKey = request.ActivationKey,
                Address = request.Address,
                Branch = request.Branch,
                Contact = request.Contact,
                Email = request.Email,
                isActive = true,
                Logo = request.Logo,
                Name = request.Name,
                RegistrationNumber = request.RegistrationNumber,
                SubscriptionEndDate = request.SubscriptionEndDate,
                SubscriptionStartDate = request.SubscriptionStartDate,
            };

            return await _instituteData.UpdateInstitute(dominModel);
        }
        public IEnumerable<InstituteRequest> GetAllInstitutes()
        {
            return _instituteData.GetAllInstitutes();
        }
        public async Task<bool> DeleteInstitute(long Id)
        {
       
            return await _instituteData.DeleteInstitute(Id);
        }

        public async Task<InstituteDomainModel> GetInstitute(long InstituteId)
        {
            return await _instituteData.GetInstitute(InstituteId);

        }
    }
}
