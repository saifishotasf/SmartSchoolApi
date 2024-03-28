using Contracts.DataContracts;
using DomainModels.Request.Standard;
using DomainModels;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.DomainContracts;
using DomainModels.Request.Institute;

namespace Data
{
    public class StandardData : IStandardData
    {
        private readonly ApplicationDbContext _context;

        public StandardData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateStandard(StandardDomainModel request)
        {
            var standard = _context.Standards.Add(new Standard
            {
                Id = request.Id,
                Name = request.Name,
                Fees = request.Fees,
                isActive = true
            });

           _context.SaveChanges();

            return true;
        }

        public IEnumerable<StandardRequest> GetAllStandards()
        {

            var result = _context.Standards.Where(x => x.isActive).Select(standard => new StandardRequest
                         
                         {
                            Id = standard.Id,
                            Name = standard.Name,
                            Fees = standard.Fees,
                         }).ToList();

            return result;
        }
        public async Task<StandardDomainModel> GetStandard(int StandardId)
        {


            var standard = _context.Standards.Where(x => x.Id == StandardId && x.isActive).Select(std =>

             new StandardDomainModel
            {
                
                Name = std.Name,
                isActive = std.isActive,
                Fees = std.Fees,
            }).FirstOrDefault();

            return standard;

        }

        public async Task<bool> UpdateStandard(StandardDomainModel request)
        {
            
            var standard = await _context.Standards.FindAsync(request.Id);
            if (standard != null)
            {
                standard.Name = request.Name;
                standard.Fees = request.Fees;
                
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteStandard(int Id)
        {
            var standard = await _context.Standards.Select(x => new Standard { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(f => f.Id == Id);

            if (standard != null)
            {
                standard.isActive = false;
            }
            _context.Standards.Attach(standard);
            _context.Entry(standard).Property(X => X.isActive).IsModified = true;

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

    }
    
}
