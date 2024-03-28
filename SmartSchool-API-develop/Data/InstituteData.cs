using Azure.Core;
using Contracts.DataContracts;
using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Institute;
using EntityModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class InstituteData : IInstituteData
    {
        private readonly ApplicationDbContext _context;

        public InstituteData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateInstitute(InstituteDomainModel request)
        {

            _context.Institutes.Add(new Institute
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
            });

            _context.SaveChanges();

            return true;

        }

        public IEnumerable<InstituteRequest> GetAllInstitutes()
        {

            var result =  _context.Institutes.Where(x => x.isActive).Select(institute => new
                          InstituteRequest
                         {
                             Id=institute.Id,
                             ActivationKey = institute.ActivationKey,
                             Address = institute.Address,
                             Branch = institute.Branch,
                             Contact = institute.Contact,
                             Email = institute.Email,
                             isActive = institute.isActive,
                             Logo = institute.Logo,
                             Name = institute.Name,
                             RegistrationNumber = institute.RegistrationNumber,
                             SubscriptionEndDate = institute.SubscriptionEndDate,
                             SubscriptionStartDate = institute.SubscriptionStartDate,
                         }).ToList();

            return result;
        }

        public async Task<bool> UpdateInstitute(InstituteUpdateDomainModel request)
        {
            var id = request.Id;
            var Institute = await _context.Institutes.FindAsync(id);
            if (Institute != null)
            {
                Institute.Name = request.Name;
                Institute.Address = request.Address;
                Institute.Contact = request.Contact;
                Institute.Email = request.Email;
                Institute.RegistrationNumber = request.RegistrationNumber;
                Institute.Branch = request.Branch;
                Institute.SubscriptionStartDate = request.SubscriptionStartDate;
                Institute.SubscriptionEndDate = request.SubscriptionEndDate;
                Institute.ActivationKey = request.ActivationKey;
                Institute.isActive = true;
                Institute.Logo = request.Logo;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<InstituteDomainModel> GetInstitute(long InstituteId)
        {


            var Institute = _context.Institutes.Where(x => x.Id == InstituteId && x.isActive).Select(institute =>

             new InstituteDomainModel
            {
                Id = institute.Id,
                Name = institute.Name,
                Address = institute.Address,
                Contact = institute.Contact,
                Email = institute.Email,
                RegistrationNumber = institute.RegistrationNumber,
                Branch = institute.Branch,
                SubscriptionStartDate = institute.SubscriptionStartDate,
                SubscriptionEndDate = institute.SubscriptionEndDate,
                ActivationKey = institute.ActivationKey,
                isActive = institute.isActive,
                Logo = institute.Logo,

            }).FirstOrDefault();

            return Institute;

        }
        public async Task<bool> DeleteInstitute(long Id)
        {
            var institute = await _context.Institutes.Select(x => new Institute { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(f => f.Id == Id);

            if (institute != null)
            {
                institute.isActive = false;
            }
            _context.Institutes.Attach(institute);
            _context.Entry(institute).Property(X => X.isActive).IsModified = true;

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
       
 }

