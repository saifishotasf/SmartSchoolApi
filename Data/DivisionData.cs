using Contracts.DataContracts;
using DomainModels;
using DomainModels.Request.Division;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DivisionData : IDivisionData
    {
        private readonly ApplicationDbContext _context;

        public DivisionData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDivision(DivisionDomainModel request)
        {
            var division = _context.Divisions.Add(new Division
            {
                Id = request.Id,
                Name = request.Name,
                isActive = true
            });

            _context.SaveChanges();

            return true;
        }

        public IEnumerable<DivisionRequest> GetAllDivisions()
        {
            var result = _context.Divisions.Where(x => x.isActive).Select(division => new DivisionRequest
            {
                Id = division.Id,
                Name = division.Name,
                isActive = division.isActive
            }).ToList();

            return result;
        }

        public async Task<DivisionDomainModel> GetDivision(int DivId)
        {


            var division = _context.Divisions.Where(x => x.Id == DivId && x.isActive).Select(division => 
             new DivisionDomainModel
            {
                Id= division.Id,
                Name = division.Name,
                isActive = division.isActive
            }).FirstOrDefault();

            return division;
            
        }

        public async Task<bool> UpdateDivision(DivisionDomainModel request)
        {

            var Division = await _context.Divisions.FindAsync(request.Id);
            if (Division != null)
            {
                Division.Name = request.Name;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteDivioson(int DivId)
        {
            var division = await _context.Divisions.Select(x => new Division { Id = x.Id, Name = x.Name }).FirstOrDefaultAsync(f => f.Id == DivId);

            if (division != null)
            {
                division.isActive = false;
            }
            _context.Divisions.Attach(division);
            _context.Entry(division).Property(X => X.isActive).IsModified = true;

            var result = await _context.SaveChangesAsync();

            return result > 0 ? true : false;
        }
    }
}
